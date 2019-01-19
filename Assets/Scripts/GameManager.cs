using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;

    #region SaveData
    public float playerHealth;
    public float enemyHealth;

    public int currentScene; // Cutscenes and Battle scenes.

    // https://unity3d.com/learn/tutorials/topics/scripting/persistence-saving-and-loading-data
    #endregion

    private void Awake()
    {
        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 150, 30), "Player health: " + playerHealth);
        GUI.Label(new Rect(10, 30, 150, 30), "Enemy health: " + enemyHealth);
        GUI.Label(new Rect(10, 50, 150, 30), "Scene: " + currentScene);
    }
}
