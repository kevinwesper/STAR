
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private void OnGUI()
    {
        if (GUI.Button(new Rect(650, 10, 100, 30), "Save"))
        {
            GameManager.manager.Save();
        }
        if (GUI.Button(new Rect(650, 50, 100, 30), "Load"))
        {
            GameManager.manager.Load();
        }
        if (GUI.Button(new Rect(650, 90, 100, 30), "Delete"))
        {
            GameManager.manager.Delete();
        }

        if (GUI.Button(new Rect(650, 150, 100, 30), "Scene up"))
        {
            GameManager.manager.currentScene += 1;
        }
        if (GUI.Button(new Rect(650, 190, 100, 30), "timer up"))
        {
            GameManager.manager.timePlayed += 1;
        }
    }
}
