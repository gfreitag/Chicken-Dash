using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRun : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 7.0f;
    public float acc = .07f;
    public Text textScore;
    private int score = 0;
    //public ObstacleCol stopScore;
    //private float distanceMoved ;
    //private float startPos;
    //private float currPos;
    
    
    void Start()
    {
        //startPos = transform.position.x;
        //calls distance function immediately upon starting and then calls it every 1/speed seconds 
        //score will increase at faster rate as speed increases in game
        InvokeRepeating("distance", 0, 1/speed);
    

    }

    // Update is called once per frame
    void Update()
    {
        speed += Time.deltaTime*acc;
        transform.Translate(Time.deltaTime*speed, 0,0);



        /*
        currPos = transform.position.x - startPos;
        Debug.Log("current: " + currPos);

        if (currPos == 1000f) 
        {
            Debug.Log("CHANGING SPEED");
            speed = speed + 0.5f;
            startPos = transform.position.x;
        }
        transform.Translate(Time.deltaTime*speed, 0,0);

        */

    }

    void distance() 
    {
        //update score (score is distance travelled)
           score++;
           textScore.text = score.ToString();
    
        
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
