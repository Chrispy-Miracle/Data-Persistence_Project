
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersistanceManager : MonoBehaviour
{
    public static PersistanceManager Instance;
    public string playerName;
    public int currentScore;

    public string highScoreHolder;
    public int highScore;

    public Text highScoreText;


    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }


    void Start() {

    }


    [System.Serializable]
    class SaveData {
        public string highScoreHolder;
        public int highScore;
    }

    public void SaveHighScore() {
        SaveData data = new SaveData(); 

        data.highScoreHolder = playerName;
        data.highScore = currentScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    
    public void LoadHighScore() {
        string path = Application.persistentDataPath + "/savefile.json";

        if(File.Exists(path)) {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScoreHolder = data.highScoreHolder;
            highScore = data.highScore;
        }
    }

}
