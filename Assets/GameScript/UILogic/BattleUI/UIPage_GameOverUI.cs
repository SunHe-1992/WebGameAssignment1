using System;
using System.Collections.Generic;
using System.Text;
using FairyGUI;
using PackageDebug;
using UnityEngine;
using UniFramework.Event;
using PackageBattle;

using SunHeTBS;
using UnityEngine.SceneManagement;

public class UIPage_GameOverUI : FUIBase
{

    UI_GameOverUI ui;
    protected override void OnInit()
    {
        base.OnInit();
        ui = this.contentPane as UI_GameOverUI;
        this.uiShowType = UIShowType.WINDOW;
        this.animationType = (int)FUIManager.OpenUIAnimationType.NoAnimation;
        ui.btn_mainmenu.onClick.Set(btnMainMenu);
        ui.btn_restart.onClick.Set(btnRestart);

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
        string reason = GameManager.Instance.gameOverReason.ToString();
        ui.txt_hint.text = "GAME OVER\n reason is " + reason;

    }
    void OnBtnClose()
    {
        FUIManager.Inst.HideUI(this);
    }
    void btnMainMenu()
    {
        FUIManager.Inst.ShowUI<UIPage_MenuScreen>(FUIDef.FWindow.MenuScreenUI);
        OnBtnClose();
    }
    void btnRestart()
    {
        GameManager.Instance.GameRestart();
        OnBtnClose();
    }
}
