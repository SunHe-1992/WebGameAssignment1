using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("----- Audio Clip -----")]
    public AudioClip coin;
    public static SoundManager Inst;
    [Header("----- Audio Source -----")]
    AudioSource soundSource;
    private void Awake()
    {
        Inst = this;
        DontDestroyOnLoad(this);
        soundSource = GetComponent<AudioSource>();
        soundSource.loop = false;
        soundSource.playOnAwake = false;
    }
    private void OnDestroy()
    {
        Inst = null;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance != null)
        {
            soundSource.volume = GameManager.Instance.gameSetting.musicVolume;
        }

    }
    public void PlayCoin()
    {
        if (!soundSource.isPlaying)
        {
            soundSource.clip = coin;
            soundSource.Play();
        }
    }
}
