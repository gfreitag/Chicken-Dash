using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleCol : MonoBehaviour
{

    public GameObject popup;

    // Start is called before the first frame update
    void Start()
    {

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
            popup.SetActive(true);
            Debug.Log("GAME OVER");
            switchToEnd();
        }
    }

    public void restart()
    {
        SceneManager.LoadScene("MainScene");
    }

    void switchToEnd()
    {
        SceneManager.LoadScene("EndGame");
    }
}
