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

    public void AddScore (string name, int score_up)
    {
        int newScore;
        string newName;
        int oldScore;
        string oldName;
        newScore = score_up;
        newName = name;
        
        for (int i=0;i<3;i++)
        {
            if (PlayerPrefs.HasKey("HighScore" + i))
            {
                //if new score is higher than old score
                if (PlayerPrefs.GetInt("HighScore" + i) < newScore)
                {
                    //save old scores to oldScore and oldName
                    //update present high score and name to new high score and name
                    oldScore = PlayerPrefs.GetInt("HighScore" + i);
                    oldName = PlayerPrefs.GetString("HighScoreName" + i);
                    PlayerPrefs.SetInt("HighScore" + i, newScore);
                    PlayerPrefs.SetString("HighScore" + i, newName);
                    //set newScore and newName variables to newScore and newName
                    //can update rest of table 
                    newScore = oldScore;
                    newName = oldName;
                }
            }else
            {
                PlayerPrefs.SetInt("HighScore" + i, newScore);
                PlayerPrefs.SetString("HighScore" + i, newName);
                newScore = 0;
                newName = "";
            }
        } 
    }


}
