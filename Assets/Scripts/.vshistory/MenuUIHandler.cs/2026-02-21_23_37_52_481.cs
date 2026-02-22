using System.IO;
using UnityEditor;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.LowLevelPhysics2D.PhysicsLayers;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public string PlayerName;
    public int PlayerHighScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SavePlayerName()
    {

    }

    [System.Serializable]
    class SavaData
    {
        public string PlayerName;
        public int PlayerHighScore;
    }

    public void SavePlayer()
    {
        SaveData data = new SaveData();
        data.PlayerName = PlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.PlayerName;
        }
    }
}
