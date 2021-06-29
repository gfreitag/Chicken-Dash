using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    [SerializeField] private LayerMask groundLayerMask;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2d;
    private float jumpForce = 700f;
    private float touchTime;
    private float durMin = 0.08f;
    private float durMax = 0.14f;
    public bool pause = false;
    public bool pauseToggle = false;
    private int pause_count;
    AudioSource aSource1;
    public AudioClip aClip1;
    // Start is called before the first frame update
    void Start()
    {
        //get rigidbody attached to player, so we can manipulate it
        pause_count = 0;
        rb = GetComponent<Rigidbody2D>();
        boxCollider2d =  GetComponent<BoxCollider2D>();
        aSource1 = gameObject.AddComponent<AudioSource>();
        aSource1.clip = aClip1;
    }

    // Update is called once per frame
    void Update()
    {
        //if at least one finger is on screen and the first finger has just touched screen propel rigidbody of player (so player) up y-axis by jumpforce
        if (Input.touchCount > 0  && Input.GetTouch(0).phase == TouchPhase.Began && isGrounded() && pause == false)
        {
            touchTime = Time.time;
            //rb.velocity = Vector2.up*jumpForce;
        }
        if(pause == true)
        {
            if(pauseToggle == true)
            {
                pause_count= pause_count+2;
                pauseToggle = false;
            }
            touchTime = Time.time;
        }
        if(Input.touchCount > 0  && (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)&&isGrounded())
        {
            if(pause_count==0)
            {
                float duration = Time.time - touchTime;
                rb.AddForce(transform.up*jumpForce*(Mathf.Clamp(duration,durMin,durMax)*10));
                aSource1.Play();
            }
            else
            {
                pause_count--;
            }
        }
    }

//check if player is on ground before it can jump
    bool isGrounded()
    {
        float extraHeight = 0.1f;
        //casts ray from center of player's boxcollider to just below bottom of player's boxcollider
        //returns null if it hits ground layer, returns not null if it hits ground layer
        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2d.bounds.center, Vector2.down,  (boxCollider2d.bounds.extents.y + extraHeight), groundLayerMask);
        return raycastHit.collider != null;

        //return true if you can jump, return false if you cannot

    }
}
