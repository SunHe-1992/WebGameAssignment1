/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace PackageBattle
{
    public partial class UI_AchievementUI : GComponent
    {
        public GButton btn_close;
        public GList list_achi;
        public const string URL = "ui://fstosj6ip8p4ow";

        public static UI_AchievementUI CreateInstance()
        {
            return (UI_AchievementUI)UIPackage.CreateObject("PackageBattle", "AchievementUI");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            btn_close = (GButton)GetChild("btn_close");
            list_achi = (GList)GetChild("list_achi");
        }
    }
}