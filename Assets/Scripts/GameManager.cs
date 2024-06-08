using System.Collections;
using System.Collections.Generic;
using Feif.UIFramework;
using UnityEngine;
using Feif.UI;
public class GameManager : MonoBehaviour
{
    public bool running = true;
    public static GameManager Instance;
    public GameOverReason gameOverReason = GameOverReason.Default;
    /// <summary>
    /// time limit
    /// </summary>
    public float timeLimit = 5f;
    float timer = 0;
    private void Awake()
    {
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
        timer = timeLimit;
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
    #region game settings
    public GameSetting gameSetting = new GameSetting();

    #endregion
}
public enum GameOverReason
{
    Default = 0,
    Fallen = 1,
    OverTime = 2,
    Died = 3,
}

public class GameSetting
{
    public float musicVolume = 1.0f;
}
