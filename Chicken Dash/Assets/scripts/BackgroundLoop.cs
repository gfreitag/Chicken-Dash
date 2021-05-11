using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{

    private Vector3 lastScreenPosition;
    private Vector2 screenBounds;
    private Camera mainCamera;
    public float scrollSpeed;
    public GameObject[] mountainsB;
    public GameObject[] mountainsFB;
    public GameObject[] fogB;
    public GameObject[] mountainsF;
    public GameObject[] fogF;
    public GameObject[] firB;
    public GameObject[] firF;
    public GameObject[] clouds;
    public GameObject[] ground;
    public GameObject[] sky;
    private GameObject[][] levels;

    // Start is called before the first frame update
    void Start()
    {
      mainCamera = gameObject.GetComponent<Camera>();
      screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
      lastScreenPosition = transform.position;
      levels = new GameObject[][] {mountainsB, mountainsFB, fogB, mountainsF, fogF, firB, firF, clouds, ground, sky};
    }

    // Update is called once per frame
    void Update() {}

    void repositionObjs(GameObject[] arr)
    {
        float halfObjectWidth = arr[0].GetComponent<SpriteRenderer>().bounds.extents.x;
        if(transform.position.x + screenBounds.x > arr[arr.Length-1].transform.position.x + halfObjectWidth)
        {
            arr[0].transform.position = new Vector3(arr[arr.Length-1].transform.position.x + halfObjectWidth * 2,
            arr[arr.Length-1].transform.position.y, arr[arr.Length-1].transform.position.z);
            GameObject temp = arr[0];
            for(int i=0; i<arr.Length-1; i++)
            {
              arr[i]=arr[i+1];
            }
            arr[arr.Length-1] = temp;
        }
    }

    void LateUpdate()
    {
        foreach(GameObject[] arr in levels)
        {
            repositionObjs(arr);
        }
    }
}
