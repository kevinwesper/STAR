using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{
    [SerializeField] private Button _continueButton;

    [Header("Credits")]
    [SerializeField] private GameObject _creditsScreen;
    [SerializeField] private GameObject _creditsRoll;
    [SerializeField] private Animator _creditsAnimator;
    [SerializeField] private AnimationClip _creditsAnimation;

    [Header("Options")]
    [SerializeField] private GameObject _optionsScreen;
    
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
        if (SceneManager.GetActiveScene().name == "StartScreen")
        {
            if (GameManager.manager.save)
            {
                _continueButton.interactable = true;
            }
            else
            {
                _continueButton.interactable = false;
            }
#if UNITY_WEBGL || UNITY_FACEBOOK
                _continueButton.SetActive(false);
#endif
        }
    }

    #region Menu Screen
    /// <summary>
    /// Starts a new game.
    /// </summary>
    public void NewGameButton()
    {
        GameManager.manager.Delete();

        SceneManager.LoadScene("CutsceneScreen");
    }

    /// <summary>
    /// Continues the previous game.
    /// </summary>
    public void ContinueButton()
    {
        GameManager.manager.Load();

        SceneManager.LoadScene("CutsceneScreen");
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
}
