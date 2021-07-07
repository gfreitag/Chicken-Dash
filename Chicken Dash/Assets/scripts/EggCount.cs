using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class EggCount : MonoBehaviour
{
    private int eggCount;
    public Text eggCounter;

    // Start is called before the first frame update
    void Start()
    {
        loadEggCount();
    }

    public int getEggCount()
    {
        return eggCount;
    }

    public void incEggCount()
    {
        eggCount++;
        eggCounter.text = "x"+eggCount;
    }

    public void refreshEggCount()
    {
        eggCounter.text = "x"+eggCount;
    }

    private void resetEggCount()
    {
        eggCount = 0;
        saveEggCount();
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

    private void loadEggCount()
    {
        if(File.Exists(Application.persistentDataPath +  "/eggCount.dat"))
        {
            Debug.Log("File exists");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath +  "/eggCount.dat", FileMode.Open);
            EggData data = (EggData)bf.Deserialize(file);
            file.Close();
            eggCount = data.eggCount;
            refreshEggCount();
        }
        else
        {
            Debug.Log("File does not exist");
            eggCount = 0;
        }
    }
}

[Serializable]
class EggData
{
    public int eggCount;
}
