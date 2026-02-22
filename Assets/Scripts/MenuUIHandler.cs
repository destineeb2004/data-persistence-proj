using System.IO;
using UnityEditor;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.LowLevelPhysics2D.PhysicsLayers;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public string playerName;
    public int playerHighScore;
    public InputField nameField;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    public void NewGame()
    {
        SceneManager.LoadScene(1);
        SavePlayerName();
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
        nameField.text = playerName;
    }
}
