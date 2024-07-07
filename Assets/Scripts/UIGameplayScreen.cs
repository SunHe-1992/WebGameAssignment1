using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Feif.UIFramework;
using System;
using Terresquall;

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
        [SerializeField] private Button btnJump;
        [SerializeField] private Slider sliderHP;
        [SerializeField] VirtualJoystick joystick;
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
        [UGUIButtonEvent("@BtnJump")]
        protected void OnClickBtnJump()
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
        private void Update()
        {
            RefreshHUD();
            RefreshHP();
        }


        void RefreshHUD()
        {
            var gm = GameManager.Instance;
            if (gm == null) return;
            var hero = gm.heroCtrl;
            if (hero == null) return;
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
        void SetControlTips()
        {
            string tip = null;
            if (GameManager.Instance.GetIsMobile())
            {
                tip = "move with joystick \r\ncontrol view by dragging on right screen";
            }
            else
            {
                tip = "move: WASD\r\nhold right mouse to move camera";
            }
            this.txtTitle.text = "";
        }
    }
}