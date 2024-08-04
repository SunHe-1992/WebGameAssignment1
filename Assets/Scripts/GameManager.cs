using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UniFramework.Event;
using SunHeTBS;
public class GameManager : MonoBehaviour
{
    public bool running = true;
    public static GameManager Instance;
    public GameOverReason gameOverReason = GameOverReason.Default;
    public MainCharacterController heroCtrl;

    /// <summary>
    /// time limit
    /// </summary>
    public float timeLimit = 100;
    float timer = 100;
    public bool loadSavedGame = false;
    private void Awake()
    {
        if (Instance == null)
        {
            heroCtrl = MainCharacterController.Inst;
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    private void OnDestroy()
    {
        RemoveListeners();
    }
    // Start is called before the first frame update
    void Start()
    {
        this.score = 0;
        this.timer = timeLimit;
        filePath = Application.persistentDataPath + "/" + settingFileName;
        ResumeGame();
        AddListeners();
    }
    #region event listeners
    void AddListeners()
    {
        UniEvent.AddListener(GameEventDefine.BuyInShop, QuestUpdate);
        UniEvent.AddListener(GameEventDefine.PickGold, QuestUpdate);
        UniEvent.AddListener(GameEventDefine.PickRedPotion, QuestUpdate);
        UniEvent.AddListener(GameEventDefine.PickStar, QuestUpdate);
        UniEvent.AddListener(GameEventDefine.PickTimer, QuestUpdate);
        UniEvent.AddListener(GameEventDefine.PickToxicPotion, QuestUpdate);
        UniEvent.AddListener(GameEventDefine.SummonNPC, QuestUpdate);

    }
    void RemoveListeners()
    {

    }
    void QuestUpdate(IEventMessage msg)
    {
        var data = msg as GameEventData;
        TBSPlayer.AddQuestProgress(data.questId, data.param1);
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        if (this.running)
        {
            Time.timeScale = 1;
            CheckTimer();

        }
        else
        {
            Time.timeScale = 0;
        }
    }
    public void ToggleRunning()
    {
        this.running = !this.running;
    }
    public void PauseGame()
    {
        this.running = false;
    }
    public void ResumeGame()
    {
        this.running = true;
    }

    public void GameOver(GameOverReason reason)
    {
        this.gameOverReason = reason;
        PauseGame();

        //show game over UI
        FUIManager.Inst.ShowUI<UIPage_GameOverUI>(FUIDef.FWindow.GameOverUI);
    }
    public float GetTimer()
    {
        return this.timer;
    }
    void CheckTimer()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            GameOver(GameOverReason.OverTime);
        }
    }
    public void AddTime(float value)
    {
        this.timer += value;
    }
    #region game settings
    public GameSetting gameSetting = new GameSetting();

    #endregion
    #region game score
    public int score = 0;
    public readonly int scoreMax = 100;
    public void AddScore(int value)
    {
        this.score += value;
        CheckScore();
    }
    void CheckScore()
    {
        if (this.score >= scoreMax)
        {
            GameOver(GameOverReason.Win);
        }
    }
    #endregion

    #region game coins

    public int coin = 0;
    public void AddCoin(int value)
    {
        this.coin += value;
        AudioManager.Inst.Play("coin");
        TBSPlayer.UpdateGoldAmount(value);



    }

    #endregion

    public void GameRestart()
    {
        this.running = true;
        this.score = 0;
        this.timer = timeLimit;
        if (heroCtrl != null)
        {
            heroCtrl.ResetPosition();
            heroCtrl.ResetHP();
        }
    }

    public bool GetIsMobile()
    {
        bool result = Application.isMobilePlatform;
        //test 
        //result = true;
        return result;
    }
    public void SaveGame()
    {
        var gs = gameSetting;
        if (heroCtrl != null)
        {
            gs.heroPos = heroCtrl.transform.position;
            gs.HP = heroCtrl.HP;
            gs.HPMax = heroCtrl.HPMax;
        }
        gs.score = score;
        gs.timer = timer;
        gs.coin = coin;
        SaveSettings();
    }
    public void LoadGame()
    {
        LoadSettings();
        var gs = gameSetting;
        if (heroCtrl != null)
        {
            heroCtrl.transform.position = gs.heroPos;
            heroCtrl.HP = gs.HP;
            heroCtrl.HPMax = gs.HPMax;
        }
        score = gs.score;
        coin = gs.coin;
        timer = gs.timer;
    }
    string filePath;
    string settingFileName = "Settings.json";

    public void SaveSettings()
    {
        try
        {
            // Serialize the playerData object to a JSON string
            string jsonString = JsonUtility.ToJson(GameManager.Instance.gameSetting);
            // Write the JSON string to a file
            File.WriteAllText(filePath, jsonString);
            Debug.Log("File saved to: " + filePath);
        }
        catch (IOException e)
        {
            Debug.LogError("Failed to save file: " + e.Message);
        }
    }
    public void DoLoadSavedGame()
    {
        if (loadSavedGame)
        {
            loadSavedGame = false;
            StartCoroutine(DelayLoadGame());
        }
    }
    IEnumerator DelayLoadGame()
    {
        yield return new WaitForSeconds(0.5f);
        LoadGame();
    }
    public void LoadSettings()
    {
        try
        {
            if (File.Exists(filePath))
            {
                // Read the JSON string from the file
                string jsonString = File.ReadAllText(filePath);

                // Deserialize the JSON string back into a PlayerData object
                GameManager.Instance.gameSetting = JsonUtility.FromJson<GameSetting>(jsonString);
                Debug.Log("File loaded from: " + filePath);

            }
            else
            {
                Debug.LogWarning("File not found: " + filePath);
            }
        }
        catch (IOException e)
        {
            Debug.LogError("Failed to load file: " + e.Message);
        }
        if (GameManager.Instance.gameSetting == null)
            GameManager.Instance.gameSetting = new GameSetting();
    }

    #region map obj management
    public Vector3 GenerateRandomPosition()
    {
        float x = Random.Range(1f, 8f);
        float z = Random.Range(1f, 8f);
        return new Vector3(x, 0f, z);
    }
    public void CreateNPC(string modelName)
    {
        var heroPos = heroCtrl.transform.position + GenerateRandomPosition();
        var heroQua = heroCtrl.transform.rotation;
        var npc = ObjectPool.Inst.Spawn(modelName, heroPos, heroQua);
        if (!npc.TryGetComponent<RandomMovement>(out var comp))
        {
            var ranMove = npc.AddComponent<RandomMovement>();
        }
        UniEvent.SendMessage(GameEventDefine.SummonNPC, new GameEventData(GameEventDefine.SummonNPC, 1));
    }
    public void CreateAllNPC()
    {
        for (int i = 103; i <= 110; i++)
        {
            int itemId = i;
            var cfg = ConfigManager.table.Item.Get(itemId);
            CreateNPC(cfg.ModelName);
        }
    }
    public void UnspawnAllNPC()
    {
        ObjectPool.Inst.UnspawnAll();
    }
    #endregion
}
public enum GameOverReason
{
    Default = 0,
    Fallen = 1,
    OverTime = 2,
    Died = 3,
    Win,
}

public class GameSetting
{
    public float musicVolume = 1.0f;
    public Vector3 heroPos;
    public float HP;
    public float HPMax;
    public int score;
    public float timer;
    public int coin;
}
