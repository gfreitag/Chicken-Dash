using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCount : MonoBehaviour
{
    private int eggCount;

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
    }
}
