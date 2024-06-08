using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    AudioSource musicSource;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        musicSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        musicSource.Play();
        musicSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance != null)
        {
            musicSource.volume = GameManager.Instance.gameSetting.musicVolume;
        }

    }
}
