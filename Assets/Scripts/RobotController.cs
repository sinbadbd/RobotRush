using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{

    // how fast the robot can move

    public float topSpeed = 10f;

    // tel the sprite which directio it is pointing
    bool facingRight = true;

    // get reference to animator
    Animator anim;


    // not grounded
    bool grounded = false;

    // touching the ground
    public Transform groundCheck;

    // how big circele is going to be when we check distance to the ground
    float groundRadius = 0.2f;


    // fource the jump
    public float jumpForce = 700f;



    //what layer is concidered ground
    public LayerMask whatIsGround;

    //Double jump
    bool doubleJump = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);

        if (grounded)
            doubleJump = false;


        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);


        //get move direction
        float move = Input.GetAxis("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(move * topSpeed, GetComponent<Rigidbody2D>().velocity.y);


        //
        anim.SetFloat("Speed", Mathf.Abs(move));



         if (move > 0 && !facingRight)
        {
            flip();
        } else if(move <0 && facingRight)
        {
            flip();
        }
    }

    private void Update()
    {
        if((grounded || !doubleJump) && Input.GetKeyDown(KeyCode.Space))
        {
            // not on the ground
            anim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));

            if (!doubleJump && !grounded)
                doubleJump = true;
        }
    }

    void flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;

        transform.localScale = theScale;
    }
}
