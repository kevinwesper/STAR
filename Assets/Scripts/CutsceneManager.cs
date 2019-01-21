using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    private string _cutsceneName;
    private string _cutscenePath;
    private int _cutsceneNumber;
    public int SavedNumber;

    //
    private void Start()
    {
        _cutsceneNumber = SavedNumber;
    }

    //TESTING
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextCutscene();
        }
    }

    /// <summary>
    /// Go to the next cutscene.
    /// </summary>
    public void NextCutscene()
    {
        _cutsceneNumber++;

        ChangeCutscene();
    }

    /// <summary>
    /// Skip to the next battle/finish.
    /// </summary>
    public void SkipCutscene()
    {
        if (_cutsceneNumber <= 4)
        {
            _cutsceneNumber = 5;
        }
        else if (_cutsceneNumber <= 6)
        {
            _cutsceneNumber = 7;
        }
        else if (_cutsceneNumber <= 7)
        {
            _cutsceneNumber = 8;
        }
        else if (_cutsceneNumber <= 8)
        {
            _cutsceneNumber = 9;
        }
        else if (_cutsceneNumber <= 10)
        {
            _cutsceneNumber = 11;
        }
        else
        {
            _cutsceneNumber = 13;
        }

        ChangeCutscene();
    }

    /// <summary>
    /// Change the cutscene image.
    /// </summary>
    private void ChangeCutscene()
    {
        StartCoroutine(CheckScene());

        _cutsceneName = "Cutscene_" + _cutsceneNumber;
        _cutscenePath = "Sprites/Cutscenes/" + _cutsceneName;

        Sprite sp = Resources.Load<Sprite>(_cutscenePath);
        GameObject child = transform.GetChild(0).gameObject;

        child.GetComponent<Image>().sprite = sp;
    }

    /// <summary>
    /// Checks if we should load a battle.
    /// </summary>
    /// <returns></returns>
    private IEnumerator CheckScene()
    {
        if (_cutsceneNumber == 5)
        {
            Debug.Log("Go to Hagrid");
        }
        if (_cutsceneNumber == 7)
        {
            Debug.Log("Go to Woofball");
        }
        if (_cutsceneNumber == 8)
        {
            Debug.Log("Go to Baby");
        }
        if (_cutsceneNumber == 9)
        {
            Debug.Log("Go to Crane");
        }
        if (_cutsceneNumber == 11)
        {
            Debug.Log("Go to Henry");
        }
        if (_cutsceneNumber == 13)
        {
            Debug.Log("GRATZ");
        }
        if (_cutsceneNumber == 14)
        {
            SceneManager.LoadScene("StartScreen");
        }

        yield break;
    }
}
