using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Feif.UIFramework;
using UnityEngine.SceneManagement;

namespace Feif.UI
{
    public class UIGameOverData : UIData
    {
    }

    [PanelLayer]
    public class UIGameOver : UIComponent<UIGameOverData>
    {
        [SerializeField] private Button btnMainMenu;
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
            string reason = GameManager.Instance.gameOverReason.ToString();
            this.txtTitle.text = "GAME OVER reason is " + reason;
        }

        protected override void OnHide()
        {
        }

        protected override void OnDied()
        {
        }

        [UGUIButtonEvent("@BtnMainMenu")]
        protected void OnClickBtnMainMenu()
        {
            SceneManager.LoadScene("TestScene", LoadSceneMode.Single);
            UIFrame.Show<UIMenuScreen>();
        }



    }
}