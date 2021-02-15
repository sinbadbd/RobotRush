using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



public class SaveLoadGame : MonoBehaviour
{
     public void Save()
    {
        if(!Directory.Exists(Application.dataPath + "SaveGames"))
        {
            Directory.CreateDirectory(Application.dataPath + "/SaveGames");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Create(Application.dataPath + "/SaveGames/save.rd");

            SaveManger saveManger = new SaveManger();
            saveManger.currentLavel = GameManager.gm.getCurrentLevel();

            bf.Serialize(fs, saveManger);
            fs.Close();
        }
    }
}

[System.Serializable]
class SaveManger{
    public int currentLavel;
}