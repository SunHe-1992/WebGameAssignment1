using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Inst;
    AudioSource musicSource;
    private void Awake()
    {
        if (Inst != null)
        {
            Destroy(gameObject);
            return;
        }
        Inst = this;
        DontDestroyOnLoad(this);
        musicSource = GetComponent<AudioSource>();
    }
    private void OnDestroy()
    {
        Inst = null;
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
