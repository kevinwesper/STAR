using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


[Serializable]
class PlayerData // Data that is saved.
{
    public float scene;
    public float time;
}

public class GameManager : MonoBehaviour
{
    public static GameManager manager;

    #region SaveData
    public bool save; // If save file is present/

    public float currentScene; // Cutscenes and Battle scenes.

    public float timePlayed; // Time played in seconds.
    #endregion

    public bool isPlaying;

    // Debug
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 150, 30), "Save: " + save);
        GUI.Label(new Rect(10, 30, 150, 30), "Scene: " + currentScene);
        GUI.Label(new Rect(10, 50, 150, 30), "Time: " + timePlayed);
    }

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

    private void OnEnable()
    {
        Load();
    }
    
    private void OnDisable()
    {
        if (isPlaying) // Only save data when playing.
        {
            Save();
        }
    }

    #region Saving System
    /// <summary>
    /// Save Data
    /// </summary>
    public void Save()
    {
#if UNITY_WEBGL || UNITY_FACEBOOK
        return;
#endif
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.scene = currentScene;
        data.time = timePlayed;

        bf.Serialize(file, data);
        file.Close();

        save = true;
    }

    /// <summary>
    /// Load Data
    /// </summary>
    public void Load()
    {
#if UNITY_WEBGL || UNITY_FACEBOOK
        return;
#endif
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            currentScene = data.scene;
            timePlayed = data.time;

            save = true;
        }
        else
        {
            save = false;
        }
    }

    /// <summary>
    /// Load Data
    /// </summary>
    public void Delete()
    {
#if UNITY_WEBGL || UNITY_FACEBOOK
        return;
#endif
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            File.Delete(Application.persistentDataPath + "/playerInfo.dat");
            save = false;
        }
    }
    #endregion
}