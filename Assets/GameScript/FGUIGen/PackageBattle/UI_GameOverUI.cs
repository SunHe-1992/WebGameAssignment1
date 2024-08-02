/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace PackageBattle
{
    public partial class UI_GameOverUI : GComponent
    {
        public GButton btn_restart;
        public GTextField txt_hint;
        public GButton btn_mainmenu;
        public const string URL = "ui://fstosj6il1lhm9";

        public static UI_GameOverUI CreateInstance()
        {
            return (UI_GameOverUI)UIPackage.CreateObject("PackageBattle", "GameOverUI");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            btn_restart = (GButton)GetChild("btn_restart");
            txt_hint = (GTextField)GetChild("txt_hint");
            btn_mainmenu = (GButton)GetChild("btn_mainmenu");
        }
    }
}