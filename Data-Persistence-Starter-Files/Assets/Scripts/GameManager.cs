using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class GameManager : MonoBehaviour
{
    

    public static GameManager Instance;

    public string playerName;

    public string winnerPlayer;

    public int topScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
    }
    [System.Serializable]
    class SaveData
    {
        public string winnerPlayer;
        public int topScore;

    }
    public void SaveGame()
    {
        SaveData data = new SaveData();
        data.winnerPlayer = winnerPlayer;
        data.topScore = topScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            winnerPlayer = data.winnerPlayer;
            topScore = data.topScore;
        }
    }
}