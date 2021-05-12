using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGen : MonoBehaviour
{
    public GameObject[] layouts;

    public GameObject getRandomLayout()
    {
        int num = Random.Range(0, layouts.Length);
        GameObject clone = Instantiate(layouts[num]) as GameObject;
        return clone;
    }
}
