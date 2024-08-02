using System;
using System.Collections.Generic;
using System.Text;
using FairyGUI;
using PackageDebug;
using UnityEngine;
using UniFramework.Event;
using PackageBattle;

public class UIPage_RunnerGame : FUIBase
{

    UI_RunnerGameUI ui;
    protected override void OnInit()
    {
        base.OnInit();
        ui = this.contentPane as UI_RunnerGameUI;
        this.uiShowType = UIShowType.WINDOW;
        this.animationType = (int)FUIManager.OpenUIAnimationType.NoAnimation;
        ui.btn_save.onClick.Set(btnSaveGame);
        ui.btn_jump.onClick.Set(btnJump);
        ui.btn_pause.onClick.Set(OnClickBtnPause);
        ui.btn_resume.onClick.Set(OnClickBtnResume);
        ui.btn_inventory.onClick.Set(btnInventory);
        ui.btn_store.onClick.Set(btnStore);

    }
    protected override void OnShown()
    {
        base.OnShown();

    }


    public override void Refresh(object param)
    {
        base.Refresh(param);

        RefreshContent();
    }
    protected override void OnHide()
    {
        base.OnHide();

    }
    void BtnOKClick()
    {
        FUIManager.Inst.ShowUI<UIPage_Debug>(FUIDef.FWindow.TestUI);
        FUIManager.Inst.HideUI(this);
    }

    void RefreshContent()
    {


    }
    void OnBtnClose()
    {
        FUIManager.Inst.HideUI(this);
    }

    void btnJump()
    {
        //test jump
        Debug.Log("jump");
        MoveBehaviour.clickJump = true;
        DelayInvoker.Inst.DelayInvoke(SetJumpState, 0.2f);
    }
    void SetJumpState()
    {
        MoveBehaviour.clickJump = false;

    }

    void btnSaveGame()
    {
        Debug.Log("BtnSaveGame");
        GameManager.Instance.SaveGame();
        TBSPlayer.SavePlayer();
    }

    protected void OnClickBtnPause()
    {
        GameManager.Instance.PauseGame();
        RefreshGameRunning();
    }
    protected void OnClickBtnResume()
    {
        GameManager.Instance.ResumeGame();
        RefreshGameRunning();
    }
    void RefreshGameRunning()
    {
        int idx = GameManager.Instance.running ? 0 : 1;
        ui.ctrl_paused.selectedIndex = idx;

    }
    void btnInventory()
    {
        FUIManager.Inst.ShowUI<UIPage_Inventory>(FUIDef.FWindow.InventoryUI);
    }
    void btnStore()
    {
        FUIManager.Inst.ShowUI<UIPage_Store>(FUIDef.FWindow.StoreUI);
    }
    protected override void OnUpdate()
    {
        base.OnUpdate();
        RefreshHUD();
        RefreshHP();
    }

    #region refresh hud
    void RefreshHUD()
    {
        var gm = GameManager.Instance;
        if (gm == null) return;
        var hero = gm.heroCtrl;
        if (hero == null) return;
        string hud = "";
        string strRun = "";
        bool running = GameManager.Instance.running;

        if (running)
        {
            strRun = "game running";
        }
        else
        {
            strRun = "game paused";
        }
        TimeSpan ts = TimeSpan.FromSeconds(GameManager.Instance.GetTimer());
        string formattedTime = string.Format("{0:D2}:{1:D2}", ts.Minutes, ts.Seconds);

        string scoreStr = $"Score: {gm.score}/{gm.scoreMax}";


        hud += strRun + "\n";
        hud += formattedTime + "\n";
        hud += scoreStr + "\n";

        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            Vector2 touchPositionPercentage = new Vector2(
         (touch.position.x / Screen.width) * 100,
         (touch.position.y / Screen.height) * 100
     );
            hud += $"touch pos = {touch.position} pct={touchPositionPercentage}\n";
        }

        hud += $"click Jump : {MoveBehaviour.clickJump}";
        ui.txt_HUD.text = hud;
    }

    void RefreshHP()
    {
        if (GameManager.Instance != null)
        {
            var hero = GameManager.Instance.heroCtrl;
            if (hero != null)
            {
                ui.sliderHP.max= hero.HPMax;
                ui.sliderHP.value = hero.HP;
            }
        }

    }
    #endregion
}
