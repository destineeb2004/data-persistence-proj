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

    public InputField nameField;

    public void NameChanged(string name)
    {
        SaveData.instance.playerName = name;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nameField.onValueChanged.AddListener(NameChanged);
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

    
}
