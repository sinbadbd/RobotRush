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




    //slide down
    bool sliding = false;
    float slideTimer = 0f;
    public float maxSlideTime = 1.5f;

    [SerializeField]
    GameObject healthController;


    // BULLET

    public Transform muzzle;
    public GameObject bullet;


    AudioManager audioManager;


    void Start()
    {
        audioManager = AudioManager.instance;
        anim = GetComponent<Animator>();
        anim.SetBool("isDead", false);
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
        GetInputMovement();
    }


    public void GetInputMovement()
    {
        if ((grounded || !doubleJump) && Input.GetKeyDown(KeyCode.Space))
        {
            // not on the ground
            anim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));

            if (!doubleJump && !grounded)
                doubleJump = true;

        }
        else if (!grounded || doubleJump && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("doubleJumping", doubleJump);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && !sliding)
        {
            slideTimer = 0f;

            anim.SetBool("isSliding", true);
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            healthController.GetComponent<CapsuleCollider2D>().enabled = false;

            sliding = true;
        }

        if (sliding)
        {
            slideTimer += Time.deltaTime;
            if (slideTimer > maxSlideTime)
            {
                sliding = false;
                anim.SetBool("isSliding", false);
                gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
                healthController.GetComponent<CapsuleCollider2D>().enabled = true;
            }
        }


        if (Input.GetButtonDown("Fire1")){
            GameObject mBullet = Instantiate(bullet, muzzle.position, muzzle.rotation);

            audioManager.PlaySound("gun-shot");
            mBullet.transform.parent = GameObject.Find("GameManager").transform;
            mBullet.GetComponent<Renderer>().sortingLayerName = "Player";

            anim.SetBool("isShooting", true);

        }


        if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("isShooting", false);
            anim.SetBool("isShooting_running", false);
        }
        if (Input.GetButtonDown("Fire1") && GetComponent<Rigidbody2D>().velocity.x > 0) {
            anim.SetBool("isShooting_running", true);
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
