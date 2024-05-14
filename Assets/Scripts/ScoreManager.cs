using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public string playerName;
    public int score;

    public static ScoreManager Instance;

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int score;
    }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadPlayerAndScore();
    }

    public void SavePlayerAndScore()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.score = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerAndScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
            score = data.score;
        } else {
            score = 0;
        }
    }
}
