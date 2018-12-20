using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    [Header("Main Menu")]
    [SerializeField] private GameObject _quitButtonObject;
    [SerializeField] private bool SavePresent;
    [SerializeField] private Button _continueButton;

    [Header("Credits")]
    [SerializeField] private GameObject _creditsScreen;
    [SerializeField] private GameObject _creditsRoll;
    [SerializeField] private Animator _creditsAnimator;
    [SerializeField] private AnimationClip _creditsAnimation;

    [Header("Options")]
    [SerializeField] private GameObject _optionsScreen;

    private Image _cutscene;

    /// <summary>
    /// Turns off the quit button for mobile devices.
    /// Makes a function that gets called every time the scene is loaded.
    /// </summary>
    private void Awake()
    {
#if UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        _quitButtonObject.SetActive(false);
#endif

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    System.Diagnostics.Process.Start("shutdown", "/s /t 0");                                    // THIS SHUTS DOWN THE PC
        //}
    }

    /// <summary>
    /// Checls of there is a save file present and makes the continue button accessible accordingly.
    /// </summary>
    /// <param name="aScene"></param>
    /// <param name="aMode"></param>
    private void OnSceneLoaded(Scene aScene, LoadSceneMode aMode)
    {
        if (SceneManager.GetActiveScene().name == "StartScreen")
        {
            if (SavePresent)                                                                            //TODO
            {
                _continueButton.interactable = true;
            }
            else
            {
                _continueButton.interactable = false;
            }
        }
    }

    #region Menu Screen
    /// <summary>
    /// Starts a new game.
    /// </summary>
    public void NewGameButton()
    {
        SavePresent = true;
        SceneManager.LoadScene("GameScreen");
    }

    /// <summary>
    /// Continues the previous game.
    /// </summary>
    public void ContinueButton()
    {
        print("Continue pressed");
    }

    /// <summary>
    /// Go to the options screen and back.                                                                    //TODO Make options
    /// </summary>
    public void OptionsButton()
    {
        _optionsScreen.SetActive(_optionsScreen.activeInHierarchy ? false : true);
    }

    /// <summary>
    /// Go to the credits screen.
    /// </summary>
    public void CreditsButton()
    {
        IEnumerator prepareCredits = PrepareForCredits();
        StartCoroutine(prepareCredits);
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
    #endregion

    #region Credits Screen
    /// <summary>
    /// Enables credits overlay and turns buttons off.
    /// </summary>
    /// <returns></returns>
    private IEnumerator PrepareForCredits()
    {
        _creditsScreen.SetActive(true);

        yield return StartCoroutine(RollCredits());

        _creditsScreen.SetActive(false);
    }

    /// <summary>
    /// Let the credits roll.
    /// </summary>
    /// <param name="creditsTime">Time that it takes for the credits to complete.</param>
    /// <returns></returns>
    IEnumerator RollCredits()
    {
        _creditsAnimator.SetTrigger("Play");

        yield return new WaitForSeconds(_creditsAnimation.length + 1.0f);
    }
    #endregion

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

    #region Shared Screens
    /// <summary>
    /// Go back to main menu.
    /// </summary>
    public void MenuButton()
    {
        print("Menu pressed");
    }

    /// <summary>
    /// Saves data before the game is closed.
    /// </summary>
    void OnApplicationQuit()
    {
        // save game
    }
    #endregion
}
