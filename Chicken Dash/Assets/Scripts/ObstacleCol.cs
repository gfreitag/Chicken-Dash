using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;


public class ObstacleCol : MonoBehaviour
{

    public GameObject popup;
    public BackgroundLoop bgLoop;
    public DoNotDestroy dnd;
    public bool stopScore;
    public GameObject button;
    public Sprite death_sprite;
    private SpriteRenderer spriteRenderer;
    private PlayerRun pRun;
    private float jumpForce = 700f;
    private Rigidbody2D rb;
    AudioSource aSource2;
    public AudioClip aClip2;
    private bool played = false;

    //variables for high score
    public GameObject hs_popup;
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
        GameObject newPop = GameObject.Find("EndScreen");
        newPop.SetActive(false);
        stopScore = false;

        //stuff for high score
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

//uncontained references that need to be fixed before saving

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            //FindObjectOfType<GameManager>().EndGame();
            //this.GetComponent<PlayerRun>().enabled = false;
            if(played==false)
            {
                aSource2 = gameObject.AddComponent<AudioSource>();
                aSource2.clip = aClip2;
                aSource2.Play();
                played=true;
            }
            pRun = (PlayerRun) GameObject.Find("CameraManager").GetComponent(typeof(PlayerRun));
            pRun.speed = 3;
            Destroy(GetComponent<PlayerRun>());
            Destroy(GetComponent<Animator>());
            rb = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = death_sprite;
            rb.AddForce(transform.up*jumpForce*1.1f);
            Destroy(button);

            //took out the following lines and moved to closeScores function 
             /*
            popup.SetActive(true);
            Debug.Log("GAME OVER");
            dnd.updateRef();
              */
           
            //added high scores information instead 
            hs_popup.SetActive(true);
            AddScore("Yoongi", Int32.Parse(finalScore.text));
            //switchToEnd();
          
        }
    }

    IEnumerator DeathJump()
    {

        yield return null;
    }

    public void restart()
    {
        //foreach (Transform child in GameObject.Find("DontDestroyOnLoad").transform)
        //{
            //Destroy(child);
        //}
        /*GameObject[] lst = SceneManager.GetActiveScene().GetRootGameObjects();
        Debug.Log("OBJECTS: "+lst);
        foreach(GameObject ob in lst)
        {
            Debug.Log("OB: "+ob);
        }*/
        SceneManager.LoadScene("MainScene");
    }

    void switchToEnd()
    {
        SceneManager.LoadScene("EndGame");
    }

    public void switchToMenu()
    {
        SceneManager.LoadScene("MainMenu");
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

    //reset high scores for REset button --> still have to create  
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

//close out of high scores pop up and go to end screen 
    public void closeScores()
    {
        hs_popup.SetActive(false);
        popup.SetActive(true);
        Debug.Log("GAME OVER");
        dnd.updateRef();

    }

    
}
