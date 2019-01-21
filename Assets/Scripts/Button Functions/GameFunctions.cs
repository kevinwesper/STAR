using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameFunctions : MonoBehaviour
{
    /// <summary>
    /// Makes a function that gets called every time the scene is loaded.
    /// </summary>
    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    /// <summary>
    /// Checks if there is a save file present and makes the continue button accessible accordingly.
    /// </summary>
    /// <param name="aScene"></param>
    /// <param name="aMode"></param>
    private void OnSceneLoaded(Scene aScene, LoadSceneMode aMode)
    {
        // new game or continue
    }
    
    #region Cutscenes
    /// <summary>
    /// Go to next "scene".
    /// </summary>
    public void NextButton()
    {
        print("Next pressed");
    }

    /// <summary>
    /// Go to next "scene".
    /// </summary>
    public void SkipButton()
    {
        print("Skip pressed");
    }
    #endregion
}
