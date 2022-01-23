using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int highscore;
    public string p_name;
    public string highScoreName;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Debug.Log(Application.persistentDataPath);
        LoadHighScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int HighScore;
        public string HighScoreName;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.HighScore = highscore;
        data.HighScoreName = highScoreName;

        string json = JsonUtility.ToJson(data);
        Debug.Log(json);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highscore = data.HighScore;
            highScoreName = data.HighScoreName;
        }
        else
        {
            Debug.Log("Cannot find data");
        }
    }
}
