using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour            // Json or binary???
{
    public SaveData saveData;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            SaveGame(saveData, 0);

        if (Input.GetKeyDown(KeyCode.L))
            saveData = LoadGame(0);
    }

    static void SaveGame(SaveData data, int characterSlot)
    {
        PlayerPrefs.SetInt("checkpointReached" + characterSlot, data.checkpoint);
        PlayerPrefs.SetInt("hoursPlayed" + characterSlot, data.hours);
        PlayerPrefs.SetInt("minutesPlayed" + characterSlot, data.minutes);
        PlayerPrefs.SetInt("secondsPlayed" + characterSlot, data.seconds);
        PlayerPrefs.Save();
    }

    static SaveData LoadGame(int characterSlot)
    {
        SaveData loadedCharacter = new SaveData();
        loadedCharacter.checkpoint = PlayerPrefs.GetInt("checkpointReached" + characterSlot);
        loadedCharacter.hours = PlayerPrefs.GetInt("hoursPlayed" + characterSlot);
        loadedCharacter.minutes = PlayerPrefs.GetInt("minutesPlayed" + characterSlot);
        loadedCharacter.seconds = PlayerPrefs.GetInt("secondsPlayed" + characterSlot);

        return loadedCharacter;
    }

    private void CreateData()
    {

    }

    private void LoadData()
    {

    }

    private void ReadData()
    {

    }

    private void SaveData()
    {

    }

    private void DeleteData()
    {

    }
}