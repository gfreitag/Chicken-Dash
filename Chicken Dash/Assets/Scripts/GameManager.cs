using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    bool gameHasEnded = false;
    public float restartTime = 3f;
    public GameObject popup;

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            
            //Invoke("Restart", restartTime);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



}
