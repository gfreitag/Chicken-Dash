 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{

    private Vector3 lastScreenPosition;
    private Vector2 screenBounds;
    private Camera mainCamera;
    private RandomGen randgen;
    public float scrollSpeed;
    public DoNotDestroy dnd;
    //arrays of the different background objects
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
      randgen = GameObject.Find("ObstacleManager").GetComponent<RandomGen>();
      mainCamera = gameObject.GetComponent<Camera>();
      screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
      lastScreenPosition = transform.position;
      levels = new GameObject[][] {mountainsB, mountainsFB, fogB, mountainsF, fogF, firB, firF, clouds, ground, sky};
    }

    // Update is called once per frame
    void Update() {}

    //moves the background elements as the character moves across the screen.
    void repositionObjs(GameObject[] arr)
    {
        float halfObjectWidth = arr[0].GetComponent<SpriteRenderer>().bounds.extents.x;
        //checks against the position of the edge of the screen
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

    void generateNewLayout(GameObject[] arr)
    {
        SpriteRenderer childSprite = (SpriteRenderer) arr[0].GetComponentInChildren(typeof(SpriteRenderer));

        float halfObjectWidth = childSprite.bounds.extents.x;
        if(transform.position.x + screenBounds.x > arr[arr.Length-1].transform.position.x + halfObjectWidth)
        {
            Vector3 newpos = new Vector3(arr[arr.Length-1].transform.position.x + halfObjectWidth * 2,
            arr[arr.Length-1].transform.position.y, arr[arr.Length-1].transform.position.z);
            Destroy(arr[0]);
            for(int i=0; i<arr.Length-1; i++)
            {
              arr[i]=arr[i+1];
            }
            GameObject newLayout = randgen.getRandomLayout();
            BoxCollider2D collider = (BoxCollider2D) newLayout.GetComponentInChildren(typeof(BoxCollider2D));
            collider.enabled = true;
            newLayout.transform.position = newpos;
            newLayout.layer = 6;
            arr[arr.Length-1] = newLayout;
        }
    }

    void parallaxTransform(GameObject[] arr)
    {
        foreach(GameObject obj in arr)
        {
          float parallaxSpeed = 1 - Mathf.Clamp01(Mathf.Abs(transform.position.z / obj.transform.position.z));
          float difference = transform.position.x - lastScreenPosition.x;
          obj.transform.Translate(Vector3.right * difference * parallaxSpeed);
        }
    }

    void LateUpdate()
    {
        foreach(GameObject[] arr in levels)
        {
            if(arr!=ground)
            {
                repositionObjs(arr);
                parallaxTransform(arr);
            }
            else
            {
                generateNewLayout(arr);
            }
        }
        lastScreenPosition = transform.position;
    }
}
