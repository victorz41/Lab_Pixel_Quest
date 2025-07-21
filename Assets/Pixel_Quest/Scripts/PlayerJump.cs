using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    //Capsule
    public float CapsuleHeight = 0.25f;
    public float CapsuleRadius = 0.08f;

    //Ground Check
    public Transform feetCollider;
    public LayerMask groundMask;
    private bool _groundCheck;
    private float fallForce = 4;
    private Vector2 gravityForce;
    private Rigidbody2D rb;
    public float jumpForce = 10;
    public bool _waterCheck;
    
    // Start is called before the first frame update
    void Start()
    {
        gravityForce = new Vector2(0f, Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _groundCheck = Physics2D.OverlapCapsule(feetCollider.position,
            new Vector2(CapsuleHeight, CapsuleRadius), CapsuleDirection2D.Horizontal,
            0, groundMask);
        if (Input.GetKeyDown(KeyCode.Space) && (_groundCheck || _waterCheck))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce);
        }
        if (rb.velocity.y <= 0 && !_waterCheck)
        {
            rb.velocity += gravityForce * (fallForce * Time.deltaTime);
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Water")
        {
            _waterCheck = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Water")
        {
            _waterCheck = false;
        }
    }
}
