using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Feif.UIFramework;

namespace Feif.UI
{
    public class UIMenuScreenData : UIData
    {
    }

    [PanelLayer]
    public class UIMenuScreen : UIComponent<UIMenuScreenData>
    {
        [SerializeField] private Button btnNewGame;
        [SerializeField] private Button btnLoadGame;
        [SerializeField] private Button btnOptions;
        [SerializeField] private Button btnExit;
        [SerializeField] private Button btnTest;
        [SerializeField] private Text txtTitle;

        protected override Task OnCreate()
        {
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

        [UGUIButtonEvent("@BtnNewGame")]
        protected void OnClickBtnNewGame()
        {
        }

        [UGUIButtonEvent("@BtnLoadGame")]
        protected void OnClickBtnLoadGame()
        {
        }

        [UGUIButtonEvent("@BtnOptions")]
        protected void OnClickBtnOptions()
        {
            UIFrame.Show<UIOptions>();
        }

        [UGUIButtonEvent("@BtnExit")]
        protected void OnClickBtnExit()
        {
        }

        [UGUIButtonEvent("@BtnTest")]
        protected void OnClickBtnTest()
        {
        }

    }
}