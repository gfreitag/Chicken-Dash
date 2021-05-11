using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManRun : MonoBehaviour
{
    private float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime*speed, 0,0);
    }
}
