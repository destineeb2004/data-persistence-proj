using System.IO;
using TMPro;
using UnityEditor;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.LowLevelPhysics2D.PhysicsLayers;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public static MenuUIHandler Instance { get; private set; }
    public TMP_InputField nameField;
    public TextMeshProUGUI please;

    private void Awake()
    {
        Instance = this;

    }
    


    public void NewGame()
    {
        if(SaveData.instance.playerName == null || SaveData.instance.playerName == "")
        {
            Debug.Log("Name can't be null!");
            please.gameObject.SetActive(true);
            Invoke("DisableWarning", 5);
        } else
        {
            SceneManager.LoadScene(1);
        }
    }

    public void ExitGame()
    {
        SaveData.instance.SaveHighScore();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void DisableWarning()
    {
        please.gameObject.SetActive(false);
    }

    public void UpdateName()
    {
        SaveData.instance.playerName = nameField.text;
    }
}
