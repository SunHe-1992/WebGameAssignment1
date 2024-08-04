/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace PackageBattle
{
    public partial class UI_RunnerGameUI : GComponent
    {
        public Controller ctrl_paused;
        public GButton btn_jump;
        public GButton btn_pause;
        public GButton btn_resume;
        public GTextField txt_title;
        public GTextField txt_HUD;
        public GButton btn_save;
        public UI_ProgressBar1 sliderHP;
        public GButton btn_inventory;
        public GButton btn_store;
        public GButton btn_quest;
        public GButton btn_achi;
        public const string URL = "ui://fstosj6il1lhm8";

        public static UI_RunnerGameUI CreateInstance()
        {
            return (UI_RunnerGameUI)UIPackage.CreateObject("PackageBattle", "RunnerGameUI");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            ctrl_paused = GetController("ctrl_paused");
            btn_jump = (GButton)GetChild("btn_jump");
            btn_pause = (GButton)GetChild("btn_pause");
            btn_resume = (GButton)GetChild("btn_resume");
            txt_title = (GTextField)GetChild("txt_title");
            txt_HUD = (GTextField)GetChild("txt_HUD");
            btn_save = (GButton)GetChild("btn_save");
            sliderHP = (UI_ProgressBar1)GetChild("sliderHP");
            btn_inventory = (GButton)GetChild("btn_inventory");
            btn_store = (GButton)GetChild("btn_store");
            btn_quest = (GButton)GetChild("btn_quest");
            btn_achi = (GButton)GetChild("btn_achi");
        }
    }
}