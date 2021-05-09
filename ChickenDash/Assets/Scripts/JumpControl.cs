using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5;
    private Rigidbody rb;
    public LayerMask groundLayers;
    public float jumpForce = 7;
    public SphereCollider col;

    #region Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement*speed);

        if (Input.touchCount > 0)
        {
            rb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, 
        new Vector3(col.bounds.center.x,col.bounds.min.y, col.bounds.center.z), 
        col.radius*.9f, groundLayers);
    }
    #endregion
}
