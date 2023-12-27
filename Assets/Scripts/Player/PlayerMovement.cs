using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private float dirX = 0f;


    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 16f;

    public Transform gunTip;  // khai bao sung
    public GameObject bullet; // khai bao vien dan
    private enum MovementState { idle,running,jumping,falling }

    [SerializeField] private AudioSource jumpSoundEffect;    
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);        
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();

        if (Shared.savebuffspeed != 0)
        {
            moveSpeed = Shared.savebuffspeed;
        }
        else
        {
            moveSpeed   = 7f;
        }
    }

  
    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {   
            state = MovementState.running;
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state= MovementState.falling;
        }

            anim.SetInteger("state", (int)state);
    }    
    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f,jumpableGround);
    }


    
}

