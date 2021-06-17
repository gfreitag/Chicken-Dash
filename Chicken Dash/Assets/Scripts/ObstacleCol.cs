using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleCol : MonoBehaviour
{

    public GameObject popup;
    public BackgroundLoop bgLoop;
    public DoNotDestroy dnd;

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
            dnd.objs[0]=bgLoop.ground[0];
            dnd.objs[1]=bgLoop.ground[1];
            dnd.updateRef();
            switchToEnd();
        }
    }

    public void restart()
    {
        for(int i=0; i<dnd.objs.Length; i++)
        {
            if(dnd.objs[i]!=null)
            {
                    Destroy(dnd.objs[i]);
            }
        }
        SceneManager.LoadScene("MainScene");
    }

    void switchToEnd()
    {
        SceneManager.LoadScene("EndGame");
    }
}
