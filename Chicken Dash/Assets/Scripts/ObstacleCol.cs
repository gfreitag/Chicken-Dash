using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleCol : MonoBehaviour
{

    public GameObject popup;
    public BackgroundLoop bgLoop;
    public DoNotDestroy dnd;
    public bool stopScore;

    // Start is called before the first frame update
    void Start()
    {
        GameObject newPop = GameObject.Find("EndScreen");
        newPop.SetActive(false);
        stopScore = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            //FindObjectOfType<GameManager>().EndGame();
            stopScore = true;
            popup.SetActive(true);
            Debug.Log("GAME OVER");
            dnd.updateRef();
            //switchToEnd();
        }
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
}
