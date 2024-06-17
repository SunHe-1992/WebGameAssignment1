using System.Collections;
using System.Collections.Generic;
using Feif.UIFramework;
using UnityEngine;
using Feif.UI;
using UnityEngine.SceneManagement;
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
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        heroCtrl = MainCharacterController.Inst;
        Instance = this;
        DontDestroyOnLoad(this);
    }
    private void OnDestroy()
    {
        Instance = null;
    }
    // Start is called before the first frame update
    void Start()
    {
        this.score = 0;
        this.timer = timeLimit;
    }

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
        UIFrame.Hide<UIGameplayScreen>();
        //show game over UI
        UIFrame.Show<UIGameOver>();
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
        SoundManager.Inst.PlayCoin();
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
}
