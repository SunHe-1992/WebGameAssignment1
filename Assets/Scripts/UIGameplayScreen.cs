using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Feif.UIFramework;

namespace Feif.UI
{
    public class UIGameplayScreenData : UIData
    {
    }

    [PanelLayer]
    public class UIGameplayScreen : UIComponent<UIGameplayScreenData>
    {
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


    }
}