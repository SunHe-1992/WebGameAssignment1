using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Feif.UIFramework;
using System.IO;

namespace Feif.UI
{
    public class UIOptionsData : UIData
    {
    }

    [WindowLayer]
    public class UIOptions : UIComponent<UIOptionsData>
    {
        [SerializeField] private Button btnBack;
        [SerializeField] private Text txtTitle;
        [SerializeField] private Slider volumeSlider;


        protected override Task OnCreate()
        {
            DontDestroyOnLoad(this);

            LoadSettings();
            volumeSlider.onValueChanged.AddListener(OnVolumeChanged);

            return Task.CompletedTask;
        }

        protected override Task OnRefresh()
        {
            return Task.CompletedTask;
        }

        protected override void OnBind()
        {
        }

        protected override void OnUnbind()
        {
        }

        protected override void OnShow()
        {
        }

        protected override void OnHide()
        {
            SaveSettings();
        }

        protected override void OnDied()
        {
        }

        [UGUIButtonEvent("@BtnBack")]
        protected void OnClickBtnBack()
        {
            UIFrame.Hide(this);
        }
        void OnVolumeChanged(float value)
        {

        }

        void LoadSettings()
        {
            GameManager.Instance.LoadSettings();
            this.volumeSlider.value = GameManager.Instance.gameSetting.musicVolume;
        }
        void SaveSettings()
        {
            //music volume
            GameManager.Instance.gameSetting.musicVolume = volumeSlider.value;
            GameManager.Instance.SaveSettings();
        }
    }
}