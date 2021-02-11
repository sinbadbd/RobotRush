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

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        //get move direction
        float move = Input.GetAxis("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(move * topSpeed, GetComponent<Rigidbody2D>().velocity.y);


        //
        anim.SetFloat("speed", Mathf.Abs(move));



         if (move > 0 && !facingRight)
        {
            flip();
        } else if(move <0 && facingRight)
        {
            flip();
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
