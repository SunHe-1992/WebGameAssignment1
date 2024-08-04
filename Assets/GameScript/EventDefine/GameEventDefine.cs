using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SunHeTBS
{

    public static class GameEventDefine
    {
        static int GenID(int module, int id)
        {
            return module * 1000 + id;
        }

        #region TBS game events
        public static int LandMarkTriggered = GenID(0, 1);
        public static int StartSlotGame = GenID(0, 2);
        public static int StartFishing = GenID(0, 3);
        public static int InputAxis = GenID(0, 4);
        public static int TurnSwitch = GenID(0, 5);
        public static int HPChanged = GenID(0, 6);
        public static int ShowActionMenu = GenID(0, 7);
        public static int NextActionPawn = GenID(0, 8);
        public static int ShowWeaponSelectUI = GenID(0, 9);
        public static int ClickConfirm = GenID(0, 10);
        public static int ClickCancel = GenID(0, 11);
        public static int OneVillianDied = GenID(0, 12);
        public static int DialogueFinished = GenID(0, 13);




        #endregion

        #region mini game events
        public static int DICE_COUNT_CHANGED = GenID(1, 1);
        public static int POINTS_CHANGED = GenID(1, 2);
        public static int Building_Changed = GenID(1, 3);
        public static int PawnJumpStop = GenID(1, 4);
        //same number as the Quest.xlsx id
        public static int BuyInShop = GenID(1, 14);
        public static int PickGold = GenID(1, 15);
        public static int SummonNPC = GenID(1, 16);
        public static int PickStar = GenID(1, 17);
        public static int PickRedPotion = GenID(1, 18);
        public static int PickToxicPotion = GenID(1, 19);
        public static int PickTimer = GenID(1, 20);
        #endregion
    }

}
