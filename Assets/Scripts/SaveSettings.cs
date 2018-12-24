using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSettings : MonoBehaviour
{
    public Settings settingsData;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            SavingSettings(settingsData, 0);

        if (Input.GetKeyDown(KeyCode.L))
            settingsData = LoadingSettings(0);
    }

    static void SavingSettings(Settings data, int characterSlot)
    {
        PlayerPrefs.SetInt("checkpointReached" + characterSlot, data.checkpoint);
        PlayerPrefs.SetInt("hoursPlayed" + characterSlot, data.hours);
        PlayerPrefs.SetInt("minutesPlayed" + characterSlot, data.minutes);
        PlayerPrefs.SetInt("secondsPlayed" + characterSlot, data.seconds);
        PlayerPrefs.Save();
    }

    static Settings LoadingSettings(int characterSlot)
    {
        Settings loadedCharacter = new Settings();
        loadedCharacter.checkpoint = PlayerPrefs.GetInt("checkpointReached" + characterSlot);
        loadedCharacter.hours = PlayerPrefs.GetInt("hoursPlayed" + characterSlot);
        loadedCharacter.minutes = PlayerPrefs.GetInt("minutesPlayed" + characterSlot);
        loadedCharacter.seconds = PlayerPrefs.GetInt("secondsPlayed" + characterSlot);

        return loadedCharacter;
    }
}