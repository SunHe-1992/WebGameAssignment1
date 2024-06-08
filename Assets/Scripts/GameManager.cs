using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool running = true;
    public static GameManager Instance;
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

    }

    // Update is called once per frame
    void Update()
    {
        if (this.running)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;

        }
    }
    public void ToggleRunning()
    {
        this.running= !this.running;
    }
    public void PauseGame()
    {
        this.running = false;
    }
    public void ResumeGame()
    {
        this.running = true;
    }
}
