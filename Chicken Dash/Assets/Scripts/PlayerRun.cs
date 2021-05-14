using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 7.0f;
    private float distanceMoved ;
    private float counter = 0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime*speed, 0,0);
        counter = counter+1;
         Debug.Log("distance:" + counter);

         if (counter == 2000)
         {
             counter = 0f;
             speed = speed + 0.5f;
         }
    }


   /* private void OnTriggerEnter(Collider obstacle)
    {
        if (obstacle.tag == "obstacle") 
        {
            Debug.Log("ouch!");

        }
    }
    */


}
