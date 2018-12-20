using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    private string CutsceneName;
    private string CutscenePath;
    private int CutsceneNumber;

    private void Start()
    {
        CutsceneNumber = 1;
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CutsceneNumber++;
            CutsceneName = "Cutscene_" + CutsceneNumber;
            CutscenePath = "Sprites/Cutscenes/" + CutsceneName;

            Sprite sp = Resources.Load<Sprite>(CutscenePath);
            print(sp);
            GameObject child = transform.GetChild(0).gameObject;

            child.GetComponent<Image>().sprite = sp;
        }
    }

    public void NextCutscene()
    {

    }

    public void SkipCutscene()
    {

    }
}
