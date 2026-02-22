using System.IO;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static SaveData instance;
    public string prevPlayerName;
    public string playerName;
    public int playerHighScore;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }

    [System.Serializable]

    class GameData
    {
        public string playerName;
        public int playerHighScore;
    }

    public void SaveHighScore()
    {
        GameData data = new GameData();
        data.playerName = playerName;
        data.playerHighScore = playerHighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameData data = JsonUtility.FromJson<GameData>(json);

            playerName = data.playerName;
            playerHighScore = data.playerHighScore;
        }
    }
    
}
