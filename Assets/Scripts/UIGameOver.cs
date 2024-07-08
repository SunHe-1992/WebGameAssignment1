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
        [SerializeField] private Button btnRestart;
        [SerializeField] private Text txtTitle;

        protected override Task OnCreate()
        {
            //this.btnRestart.onClick.AddListener(this.OnClickBtnRestart);
            //this.btnMainMenu.onClick.AddListener(this.OnClickBtnMainMenu);
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
            //DelayInvoker.Inst.DelayInvoke(OnClickBtnRestart, 3);
        }

        protected override void OnHide()
        {
        }

        protected override void OnDied()
        {
        }
        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.M))
            {
                this.OnClickBtnMainMenu();
            }
            if (Input.GetKeyUp(KeyCode.R))
            {
                this.OnClickBtnRestart();
            }
        }

        [UGUIButtonEvent("@BtnMainMenu")]
        public void OnClickBtnMainMenu()
        {
            Debug.Log("OnClickBtnMainMenu");
            HideThisUI();
            SceneManager.LoadScene("TestScene", LoadSceneMode.Single);
            UIFrame.Show<UIMenuScreen>();
        }

        [UGUIButtonEvent("@BtnRestart")]
        public void OnClickBtnRestart()
        {
            Debug.Log("OnClickBtnRestart");
            HideThisUI();
            GameManager.Instance.GameRestart();
            UIFrame.Show<UIGameplayScreen>();

        }
        void HideThisUI()
        {
            UIFrame.Hide();
        }

    }
}