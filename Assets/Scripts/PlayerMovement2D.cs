using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float speed; 
    public float jumpforce;

    public Transform groundCheck; 
    public LayerMask groundLayer;

    private bool isFacingRight;
    private bool InAir;
    private float horizontal; 
    private Rigidbody2D rb; 
    private Animator animator;

    //coyote time fields
    public float coyoteTime = 0.1f;
    private float coyoteTimeCounter; 
    
    //jump buffer fields
    public float jumpBufferTime = 0.1f; 
    private float jumpBufferCounter; 

    // Start is called before the first frame update
    void Start()
    {
      rb = gameObject.GetComponent<Rigidbody2D>(); //telling it to grab the game object that the script it attached to 
      animator = gameObject.GetComponentInParent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
     horizontal = Input.GetAxisRaw("Horizontal"); //only return a -1, +1 or 0 value
     if (IsGrounded())
     {
        coyoteTimeCounter = coyoteTime; 
     }
     else 
     {
        coyoteTimeCounter -= Time.deltaTime;
     }

     if(Input.GetButtonDown("Jump"))
     {
        jumpBufferCounter = jumpBufferTime;
     }

     else 
     {
        jumpBufferCounter =- Time.deltaTime;
     }

     if (jumpBufferCounter > 0f && coyoteTimeCounter>0f)
     {
   rb.velocity = new UnityEngine.Vector2(rb.velocity.x, jumpforce);
   animator.SetTrigger("IsJumping");
   jumpBufferCounter = 0;
     }
  
    if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
    {
        rb.velocity = new UnityEngine.Vector2(rb.velocity.x,rb.velocity.y * 0.5f);
      coyoteTimeCounter =0;
    }
if (horizontal == 0 && IsGrounded())
{
    rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
}

if ( horizontal != 0 || !IsGrounded())
{
    rb.constraints = RigidbodyConstraints2D.FreezeRotation;
}
    flip ();
    AnimateCharacter();

    }

    void FixedUpdate() //runs on a timebased sense instead of every frame
    {
        rb.velocity = new UnityEngine.Vector2(horizontal * speed, rb.velocity.y); 
    
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position,0.2f,groundLayer);
    }

    private void flip()
    {
        if (isFacingRight && horizontal > 0 || !isFacingRight && horizontal < 0)
        {
            isFacingRight = !isFacingRight;
          transform.Rotate(0f,180f,0f);
        }
    }

    private void AnimateCharacter()
    {
        if(horizontal != 0 && IsGrounded())
        {
            animator.SetBool("IsRunning",true);
        }
        else 
        {
            animator.SetBool ("IsRunning",false);

        }

        if (rb.velocity.y < 0.2 && !IsGrounded())
        {
            animator.SetBool("IsFalling",true);
            InAir=true;

        }

        if (IsGrounded() && InAir)
        {
            animator.SetBool ("IsFalling",false);
            animator.SetTrigger ("IsLanding");
            InAir = false;
        }
    }

}
