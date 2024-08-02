using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using UnityEngine;
using UnityEngine.UIElements;
using UniFramework.Singleton;
using UniFramework.Animation;

using UniFramework.Tween;
//using UniFramework.Window;

using SunHeTBS;
using UniFramework.Event;
using UniFramework.Module;
public class GameLoader : MonoBehaviour
{
    public static GameLoader Instance = null;

    private void Awake()
    {
        Instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {

        // 初始化事件系统
        UniEvent.Initalize();

        // 初始化管理系统
        UniModule.Initialize();

         
        this.InitEnv();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void InitEnv()
    {
       

        UniSingleton.Initialize();

        UniTween.Initalize();

     
        //init Uni singletons
        /*2d game demo */
        BattleDriver.Init();
 
        LocalServer.Init();
        MinigameService.Init();
        //framework
        FUIManager.Init();
        ConfigManager.Init();
        InputManager.Init();
        UIAnimationService.Init();
        UIService.Init();
        TBSPlayer.SetUserDetail();

        BindFGUI.BindAll();//fairy code bind 
        LoadData();//load json configs

        FUIManager.ReSetBundle();//FUIManager initialize
        LoadFontRes();

    }


    //load config data
    private void LoadData()
    {

        ConfigManager.LoadJsonInfos(() =>
        {
            Translator.Init();//load language table
            FairyGUI.TranslationHelper.translateStr = Translator.GetStr;
            //ConfigInited = true;
            //TestAfterLoadConfig();
        });
    }
    //void TestAfterLoadConfig()
    //{
    //    string testStr = Translator.GetStr("T-test");
    //    Debugger.Log("test str " + testStr);
    //}

    UnityEngine.Font loadFontObj;
    private void LoadFontRes()
    {
      
        loadFontObj = null;
        #region 字体加载
     

            LoadFontDone();
        
        #endregion
    }
    int needDoneAllNum;
    void LoadFontDone()
    {
        string fontNameStr = "OPPOSans-M";
        //DynamicFont fontHeiti = new DynamicFont(fontNameStr, loadFontObj);
        //FontManager.RegisterFont(fontHeiti, fontNameStr);

        //preload ui packages
        List<FUIDef.FPackage> packageList = new List<FUIDef.FPackage>()
        {
            FUIDef.FPackage.PackageShared,
            FUIDef.FPackage.PackageDebug,
            FUIDef.FPackage.CommonPackage,
            FUIDef.FPackage.CommonButton,

        };
        needDoneAllNum = packageList.Count;

        foreach (var package in packageList)
        {
            FUIManager.Inst.IncPackageReference(package.ToString());
            FUIManager.Inst.PreAddPackage(package.ToString(), loadCommonDone);
        }

    }

    void loadCommonDone()
    {
        needDoneAllNum = needDoneAllNum - 1;

        if (needDoneAllNum == 0)
        {
           
            AudioManager.Inst.Play("bgm1", true);
            //show test ui
            //FUIManager.Inst.ShowUI<UIPage_Debug>(FUIDef.FWindow.TestUI);
            FUIManager.Inst.ShowUI<UIPage_MenuScreen>(FUIDef.FWindow.MenuScreenUI);
            DontDestroyOnLoad(StageCamera.main);
        }
    }
}
