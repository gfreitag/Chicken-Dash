using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text finalScore;
    public Text highScoreName1;
    public Text highScoreName2;
    public Text highScoreName3;
    public Text highScore1;
    public Text highScore2;
    public Text highScore3;
    // Start is called before the first frame update
    void Start()
    {
        //set high score table scores (0 if no scores are saved)
        highScore1.text = PlayerPrefs.GetInt("HighScore" + 0, 0).ToString();
        highScore2.text = PlayerPrefs.GetInt("HighScore" + 1, 0).ToString();
        highScore3.text = PlayerPrefs.GetInt("HighScore" + 2, 0).ToString();
        highScoreName1.text = PlayerPrefs.GetString("HighScoreName" + 0, "1.XXX");
        highScoreName2.text = PlayerPrefs.GetString("HighScoreName" + 1, "2.XXX");
        highScoreName3.text = PlayerPrefs.GetString("HighScoreName" + 2, "3.XXX");
    }

    // Update is called once per frame
    void Update()
    {
        
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
                    if (i==0) 
                    {
                        highScore1.text = newScore.ToString();
                    }
                    else if (i==1)
                    {
                        highScore2.text = newScore.ToString();
                    }
                    else if (i==2)
                    {
                        highScore3.text = newScore.ToString();
                    }
                    
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
                newName = "XXX";
                if (i==0) 
                    {
                        highScore1.text = newScore.ToString();
                    }
                    else if (i==1)
                    {
                        highScore2.text = newScore.ToString();
                    }
                    else if (i==2)
                    {
                        highScore3.text = newScore.ToString();
                    }
            }
        } 
    }

//reset high scores 
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        highScore1.text = "0";
        highScore2.text = "0";
        highScore3.text = "0";
        highScoreName1.text = "1.XXX";
        highScoreName2.text = "2.XXX";
        highScoreName3.text = "3.XXX";

    }

    public void closeScores()
    {
        
    }
}
