using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Collect : MonoBehaviour
{
    //public GameObject eggTracker;
    private EggCount eggCount;
    GameObject soundPlayer;

    void Start()
    {
        eggCount = (EggCount) GameObject.Find("EggTracker").GetComponent(typeof(EggCount));
        soundPlayer = GameObject.Find("CameraManager").transform.Find("CollectSound").gameObject;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "player")
        {
            Debug.Log("enter");
            soundPlayer.GetComponent<AudioSource>().Play();
            eggCount.incEggCount();
            Destroy (gameObject);
        }
    }
}
