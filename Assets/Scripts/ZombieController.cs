using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{


    public float health = 100f;
    public Transform target;
    public float enguageDistance = 10f;

    public float attackDistance = 3f;
    public float moveSpeed = 5f;
    private bool facingLeft = true;


    private Animator anim;

    public RobotController robotController;

    public float attackDamage = 2f;


    public SpriteRenderer healthBar;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isIdle", true);
        anim.SetBool("isWalking", false);

        anim.SetBool("isAttack", true);
        //anim.SetBool("isDead", true);

        if (Vector3.Distance(target.position, this.transform.position) < enguageDistance)
        {
            anim.SetBool("isIdle", false);

            Vector3 direction = target.position - this.transform.position;

            if(Mathf.Sign(direction.x) == 1 && facingLeft)
            {
                Flip();
            }
            else if(Mathf.Sign(direction.x) == -1 && !facingLeft)
            {
                Flip();
            }


            if(direction.magnitude >= attackDistance)
            {
                anim.SetBool("isWalking", true);

                Debug.DrawLine(target.transform.position, this.transform.position, Color.yellow);

                if (facingLeft)
                {
                    this.transform.Translate(Vector3.left * (Time.deltaTime * moveSpeed));
                }else if (!facingLeft)
                {
                    this.transform.Translate(Vector3.right * (Time.deltaTime * moveSpeed));

                }
            }

            if(direction.magnitude < attackDistance)
            {
                anim.SetBool("isAttack", true);
                Debug.DrawLine(target.transform.position, this.transform.position, Color.yellow);

                robotController.GetComponentInChildren<PlayerHeath>().currentHealth -= attackDamage;
            }


        }
        else if(Vector3.Distance(target.position, this.transform.position) > enguageDistance)
        {
            // do nothing
            Debug.DrawLine(target.position, this.transform.position, Color.green);
        }
    }



    public void Flip()
    {
        facingLeft = !facingLeft;
        Vector3 thisScale = transform.localScale;
        thisScale.x *= -1;
        transform.localScale = thisScale;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            health -= 10;
            healthBar.GetComponent<Transform>().localScale -= new Vector3(.1f, 0, 0);
            if(health <= 0)
            {
                anim.SetBool("isDead", true);
                Destroy(gameObject, 2);
            }
            
        }
    }
}
