using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Feif.UIFramework;
using System;

namespace Feif.UI
{
    public class UIGameplayScreenData : UIData
    {
    }

    [PanelLayer]
    public class UIGameplayScreen : UIComponent<UIGameplayScreenData>
    {
        [SerializeField] private Text txtTitle;
        [SerializeField] private Text txtHUD;
        [SerializeField] private Button btnPause;
        [SerializeField] private Button btnResume;
        [SerializeField] private Slider sliderHP;

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

        [UGUIButtonEvent("@BtnPause")]
        protected void OnClickBtnPause()
        {
            GameManager.Instance.ToggleRunning();
        }
        [UGUIButtonEvent("@BtnResume")]
        protected void OnClickBtnResume()
        {
            GameManager.Instance.ToggleRunning();
        }
        private void Update()
        {
            RefreshHUD();
            RefreshHP();
        }


        void RefreshHUD()
        {
            var gm = GameManager.Instance;
            string hud = "";
            string strRun = "";
            bool running = GameManager.Instance.running;
            this.btnPause.gameObject.SetActive(running);
            this.btnResume.gameObject.SetActive(!running);
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
            this.txtHUD.text = hud;
        }

        void RefreshHP()
        {
            if (GameManager.Instance != null)
            {
                var hero = GameManager.Instance.heroCtrl;
                if (hero != null)
                {
                    this.sliderHP.value = hero.HP / hero.HPMax;
                }
            }

        }
    }
}