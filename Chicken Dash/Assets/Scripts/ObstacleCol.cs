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
    public GameObject button;
    public Sprite death_sprite;
    private SpriteRenderer spriteRenderer;
    private PlayerRun pRun;
    private float jumpForce = 700f;
    private Rigidbody2D rb;
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

//uncontained references that need to be fixed before saving

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            //FindObjectOfType<GameManager>().EndGame();
            //this.GetComponent<PlayerRun>().enabled = false;
            pRun = (PlayerRun) GameObject.Find("CameraManager").GetComponent(typeof(PlayerRun));
            pRun.speed = 3;
            Destroy(GetComponent<PlayerRun>());
            Destroy(GetComponent<Animator>());
            rb = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = death_sprite;
            rb.AddForce(transform.up*jumpForce*1.1f);
            Destroy(button);
            popup.SetActive(true);
            Debug.Log("GAME OVER");
            dnd.updateRef();
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
}
