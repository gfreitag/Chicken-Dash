using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Collect : MonoBehaviour
{
    //public GameObject eggTracker;
    private EggCount eggCount;
    public AudioClip aClip;
    private AudioSource aSource;

    void Start()
    {
        aSource = gameObject.AddComponent<AudioSource>();
        aSource.clip = aClip;
        eggCount = (EggCount) GameObject.Find("EggTracker").GetComponent(typeof(EggCount));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "player")
        {
            Debug.Log("enter");
            aSource.Play();
            eggCount.incEggCount();
            Destroy (gameObject);
        }
    }
}
