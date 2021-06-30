using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Collect : MonoBehaviour
{
    //public GameObject eggTracker;
    private EggCount eggCount;
    AudioSource audioData;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        eggCount = (EggCount) GameObject.Find("EggTracker").GetComponent(typeof(EggCount));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        audioData = GetComponent<AudioSource>();
        if (other.gameObject.tag == "player")
        {
            Debug.Log("enter");
            audioData.Play();
            eggCount.incEggCount();
            Destroy (gameObject);
        }
    }
}
