using System.Collections;
using UniFramework.Event;
using UniFramework.Module;
using UnityEngine;


public class Boot : MonoBehaviour
{
    /// <summary>
    /// 资源系统运行模式
    /// </summary>
    public GameObject gameLoader;
    public static bool playRPG = false;
    void Awake()
    {

        Application.targetFrameRate = 60;
        Application.runInBackground = true;
    }
    IEnumerator Start()
    {


        gameLoader.SetActive(true);
        yield return null;
    }
}
