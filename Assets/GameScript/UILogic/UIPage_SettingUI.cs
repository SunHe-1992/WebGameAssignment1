using System;
using System.Collections.Generic;
using System.Text;
using FairyGUI;
using PackageDebug;
using UnityEngine;
using UniFramework.Event;
using PackageBattle;

public class UIPage_SettingUI : FUIBase
{

    UI_SettingUI ui;
    protected override void OnInit()
    {
        base.OnInit();
        ui = this.contentPane as UI_SettingUI;
        this.uiShowType = UIShowType.WINDOW;
        this.animationType = (int)FUIManager.OpenUIAnimationType.NoAnimation;
        ui.btn_close.onClick.Set(OnBtnClose);
    }
    protected override void OnShown()
    {
        base.OnShown();
        LoadSettings();
 
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
        LoadSettings();

    }

    private void LoadSettings()
    {
        GameManager.Instance.LoadSettings();
        ui.volume_slider.value = GameManager.Instance.gameSetting.musicVolume;
    }

    void OnBtnClose()
    {
        FUIManager.Inst.HideUI(this);
        SaveSettings();
    }
    void SaveSettings()
    {
        //music volume
        GameManager.Instance.gameSetting.musicVolume = (float)ui.volume_slider.value;
        GameManager.Instance.SaveSettings();
    }
}
