using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggCount : MonoBehaviour
{
    private int eggCount;
    public Text eggCounter;

    // Start is called before the first frame update
    void Start()
    {
        eggCount = 0;
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
}
