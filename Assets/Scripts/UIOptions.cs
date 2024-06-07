using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Feif.UIFramework;
using System.IO;

namespace Feif.UI
{
    public class UIOptionsData : UIData
    {
    }
    public class GameSetting
    {
        public float musicVolume = 1.0f;
    }
    [WindowLayer]
    public class UIOptions : UIComponent<UIOptionsData>
    {
        [SerializeField] private Button btnBack;
        [SerializeField] private Text txtTitle;
        [SerializeField] private Slider volumeSlider;

        GameSetting gameSetting;
        string settingFileName = "Settings.json";
        string filePath;
        protected override Task OnCreate()
        {
            DontDestroyOnLoad(this);

            filePath = Application.persistentDataPath + "/" + settingFileName;
            LoadSettings();
            volumeSlider.onValueChanged.AddListener(OnVolumeChanged);

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
            SaveSettings();
        }

        protected override void OnDied()
        {
        }

        [UGUIButtonEvent("@BtnBack")]
        protected void OnClickBtnBack()
        {
            UIFrame.Hide(this);
        }
        void OnVolumeChanged(float value)
        {

        }

        void LoadSettings()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    // Read the JSON string from the file
                    string jsonString = File.ReadAllText(filePath);

                    // Deserialize the JSON string back into a PlayerData object
                    this.gameSetting = JsonUtility.FromJson<GameSetting>(jsonString);
                    Debug.Log("File loaded from: " + filePath);

                }
                else
                {
                    Debug.LogWarning("File not found: " + filePath);
                }
            }
            catch (IOException e)
            {
                Debug.LogError("Failed to load file: " + e.Message);
            }
            if (this.gameSetting == null)
                this.gameSetting = new GameSetting();
            this.volumeSlider.value = gameSetting.musicVolume;
        }
        void SaveSettings()
        {
            //music volume
            gameSetting.musicVolume = volumeSlider.value;
            //settingFileName
            try
            {
                // Serialize the playerData object to a JSON string
                string jsonString = JsonUtility.ToJson(gameSetting);
                // Write the JSON string to a file
                File.WriteAllText(filePath, jsonString);
                Debug.Log("File saved to: " + filePath);
            }
            catch (IOException e)
            {
                Debug.LogError("Failed to save file: " + e.Message);
            }
        }
    }
}