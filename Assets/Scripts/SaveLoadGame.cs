using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;


public class SaveLoadGame : MonoBehaviour
{

    GameManager gameManger;


    void Awake()
    {
        gameManger = GameManager.instance;
    }


    public void Save()
    {
        if(!Directory.Exists(Application.dataPath + "SaveGames"))
        {
            Directory.CreateDirectory(Application.dataPath + "/SaveGames");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Create(Application.dataPath + "/SaveGames/save.rd");

            SaveManger saveManger = new SaveManger();
            saveManger.currentLavel = gameManger.getCurrentLevel();

            bf.Serialize(fs, saveManger);
            fs.Close();
        }
    }


    public void LoadData()
    {
        if(File.Exists(Application.dataPath + "/SaveGames/save.rd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(Application.dataPath + "/SaveGames/save.rd", FileMode.Open);

            SaveManger saveManger =  (SaveManger)bf.Deserialize(fs);


            fs.Close();
            gameManger.LoadLastSave(saveManger.currentLavel);
        }
        if(!File.Exists(Application.dataPath + "/SaveGames/save.rd"))
        {
            Debug.Log("No Saved file present!");
        }
    }

}

[System.Serializable]
class SaveManger{
    public int currentLavel;
}