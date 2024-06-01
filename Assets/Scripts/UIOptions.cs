using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Feif.UIFramework;

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
    }
}