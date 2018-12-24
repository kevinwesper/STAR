using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public SaveData saveFile;
    string dataPath;

    void Start()
    {
        dataPath = Path.Combine(Application.persistentDataPath, "saveFile.txt");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            SaveGame(saveFile, dataPath);

        if (Input.GetKeyDown(KeyCode.L))
            saveFile = LoadGame(dataPath);
    }

    static void SaveGame(SaveData data, string path)
    {
        string jsonString = JsonUtility.ToJson(data);

        using (StreamWriter streamWriter = File.CreateText(path))
        {
            streamWriter.Write(jsonString);
        }
    }

    static SaveData LoadGame(string path)
    {
        using (StreamReader streamReader = File.OpenText(path))
        {
            string jsonString = streamReader.ReadToEnd();
            return JsonUtility.FromJson<SaveData>(jsonString);
        }
    }
}

/*
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
}*/
