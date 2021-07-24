using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public int      HiScore;
    public string   HiScoreName;
    public string   CurrentName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Commenting ZeroScore in and out to reset High Score
        // ZeroScore();
        
        LoadScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int      HiScore;
        public string   HiScoreName;
    }
    public void ZeroScore()
    {
        SaveData data = new SaveData();

        data.HiScore = 0;
        data.HiScoreName = "None";

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
    }
    public void SaveScore()
    {
        SaveData data = new SaveData();
        
        data.HiScore = HiScore;
        data.HiScoreName = HiScoreName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savedata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HiScore = data.HiScore;
            HiScoreName = data.HiScoreName;
        }
    }
}
