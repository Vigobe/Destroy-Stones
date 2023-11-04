using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

[System.Serializable]
public class ControllerDataGAme : MonoBehaviour
{

    public static GameObject player;
    public string FileDat;
    public DataPlayer dataGame = new DataPlayer();

    private void Awake()
    {
        FileDat = Application.persistentDataPath + "/dataGame.json";
             
    }

    public void Update()
    {
        if (GameManager.currentNumberDestroyedStones > GameManager.currentBestScore)
        {
            SaveData();
            Debug.Log("SALVO DATOS");
        }
        
    }
    public static void LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/dataGame.json"))
        {
            string content = File.ReadAllText(Application.persistentDataPath + "/dataGame.json"); 
            DataPlayer dataGame = JsonUtility.FromJson<DataPlayer>(content);
            GameManager.bestName = dataGame.bName;
            GameManager.currentBestScore = dataGame.bScore;
            Debug.Log("Datos cargados");
        }
        else
        {
            Debug.Log("File not Found");
        }
    }

    public static void SaveData()
    {
        DataPlayer newData = new DataPlayer()
        {  
            bName =  GameManager.bestName,
            bScore = GameManager.currentBestScore
        };
        string cadenaJson = JsonUtility.ToJson(newData);
        File.WriteAllText(Application.persistentDataPath + "/dataGame.json", cadenaJson);
    }
}
