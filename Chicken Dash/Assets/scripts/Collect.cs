using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Collect : MonoBehaviour
{
    //public GameObject eggTracker;
    private EggCount eggCount;
    GameObject soundPlayer;
    public bool gameOver;

    void Start()
    {
        eggCount = (EggCount) GameObject.Find("EggTracker").GetComponent(typeof(EggCount));
        soundPlayer = GameObject.Find("CameraManager").transform.Find("CollectManager").gameObject;
        gameOver = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "player")
        {
            Debug.Log("enter");
            soundPlayer.GetComponent<AudioSource>().Play();
            if(GameObject.Find("EndScreen"))
            {
                eggCount.incEggCount();
            }
            Destroy (gameObject);
        }
    }
}
