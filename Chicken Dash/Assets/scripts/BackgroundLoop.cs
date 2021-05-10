using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{

    private Vector3 lastScreenPosition;
    private Vector2 screenBounds;
    private Camera mainCamera;
    public GameObject[] mountainsB;
    public GameObject[] mountainsFB;
    public GameObject[] fogB;
    public GameObject[] mountainsF;
    public GameObject[] fogF;
    public GameObject[] firB;
    public GameObject[] firF;
    public GameObject[] clouds;

    // Start is called before the first frame update
    void Start()
    {
      mainCamera = gameObject.GetComponent<Camera>();
      screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
      lastScreenPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
