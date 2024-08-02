using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace SUNHEUI
{
   

    public class UIGameOver 
    {
        [SerializeField] private Button btnMainMenu;
        [SerializeField] private Button btnRestart;
        [SerializeField] private Text txtTitle;

       
       

        protected  void OnShow()
        {
            string reason = GameManager.Instance.gameOverReason.ToString();
            this.txtTitle.text = "GAME OVER reason is " + reason;
            //DelayInvoker.Inst.DelayInvoke(OnClickBtnRestart, 3);
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

        public void OnClickBtnMainMenu()
        {
            Debug.Log("OnClickBtnMainMenu");
            SceneManager.LoadScene("TestScene", LoadSceneMode.Single);
            //UIFrame.Show<UIMenuScreen>();
        }

        public void OnClickBtnRestart()
        {
            Debug.Log("OnClickBtnRestart");
            GameManager.Instance.GameRestart();
            //UIFrame.Show<UIGameplayScreen>();

        }
      

    }
}