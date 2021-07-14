using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class EggCount : MonoBehaviour
{
    private int eggCount;
    public Text eggCounter;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name!="MainScene")
        {
            loadEggCount("Total Golden Eggs: x");
        }
    }

    public int getEggCount()
    {
        return eggCount;
    }

    public void incEggCount(string def = "x")
    {
        eggCount++;
        eggCounter.text = def+eggCount;
    }

    public void refreshEggCount(string def = "x")
    {

        eggCounter.text = def+eggCount;
    }

    private void resetEggCount()
    {
        eggCount = 0;
        saveEggCount();
    }

    public void setEggCount(int eggC)
    {
        eggCount = eggC;
    }

    public void saveEggCount()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath +  "/eggCount.dat");
        EggData data = new EggData();
        data.eggCount = eggCount;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("File saved");
    }

    private void loadEggCount(string def = "x")
    {
        if(File.Exists(Application.persistentDataPath +  "/eggCount.dat"))
        {
            Debug.Log("File exists");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath +  "/eggCount.dat", FileMode.Open);
            EggData data = (EggData)bf.Deserialize(file);
            file.Close();
            eggCount = data.eggCount;
            refreshEggCount(def);
            Debug.Log("File loaded");
        }
        else
        {
            Debug.Log("File does not exist");
            eggCount = 0;
        }
    }

    public int getTotalEggCount()
    {
        if(File.Exists(Application.persistentDataPath +  "/eggCount.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath +  "/eggCount.dat", FileMode.Open);
            EggData data = (EggData)bf.Deserialize(file);
            file.Close();
            return data.eggCount;
        }
        else
        {
            return 0;
        }
    }
}

[Serializable]
class EggData
{
    public int eggCount;
}
