using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    [SerializeField] private LayerMask groundLayerMask;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2d;
    private float jumpForce = 400f;
    // Start is called before the first frame update
    void Start()
    {
        //get rigidbody attached to player, so we can manipulate it
        rb = GetComponent<Rigidbody2D>();
        boxCollider2d =  GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if at least one finger is on screen and the first finger has just touched screen propel rigidbody of player (so player) up y-axis by jumpforce
        if (Input.touchCount > 0  && Input.GetTouch(0).phase == TouchPhase.Began && isGrounded())
        {
            rb.AddForce(transform.up*jumpForce);
            //rb.velocity = Vector2.up*jumpForce;
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
