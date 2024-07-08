using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Feif.UIFramework;
using UnityEngine.SceneManagement;
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
            DontDestroyOnLoad(this);
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
            SceneManager.LoadScene("GameScene");
            UIFrame.Show<UIGameplayScreen>();
        }

        [UGUIButtonEvent("@BtnLoadGame")]
        protected void OnClickBtnLoadGame()
        {
            GameManager.Instance.loadSavedGame = true;
            OnClickBtnNewGame();
        }

        [UGUIButtonEvent("@BtnOptions")]
        protected void OnClickBtnOptions()
        {
            UIFrame.Show<UIOptions>();
        }

        [UGUIButtonEvent("@BtnExit")]
        protected void OnClickBtnExit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }

        [UGUIButtonEvent("@BtnTest")]
        protected void OnClickBtnTest()
        {
        }

    }
}