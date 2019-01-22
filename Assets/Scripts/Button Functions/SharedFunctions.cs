using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SharedFunctions : MonoBehaviour
{
    [SerializeField] private GameObject _quitButtonObject;

    /// <summary>
    /// Turns off the quit button for mobile devices.
    /// Makes a function that gets called every time the scene is loaded.
    /// </summary>
    private void Awake()
    {
#if UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        _quitButtonObject.SetActive(false);
#endif
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuButton();
        }
    }

    /// <summary>
    /// Quits the application.
    /// (Is removed for mobile devices)
    /// </summary>
    public void QuitButton()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
        Application.Quit();
#endif
    }

    /// <summary>
    /// Go back to main menu.
    /// </summary>
    public void MenuButton()
    {
        //if (SceneManager.GetActiveScene().name != "StartScreen")          // here or somewhere else
        //{
        //    GameManager.manager.Save();
        //}

        SceneManager.LoadScene("StartScreen");
    }

    public void DropDownButton(GameObject button)
    {
        for (int i = 0; i < button.transform.parent.transform.childCount; i++) // Get backdrop
        {
            if (button.transform.parent.transform.GetChild(i) != button.transform)
            {
                button.transform.parent.transform.GetChild(i).gameObject.SetActive(!button.transform.parent.transform.GetChild(i).gameObject.activeSelf);
            }
        }

        for (int i = 0; i < button.transform.childCount; i++) // get child buttons
        {
            button.transform.GetChild(i).gameObject.SetActive(!button.transform.GetChild(i).gameObject.activeSelf);
        }
    }
}
