using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update

    public float bulletSpeed;

    public RobotController player;



    void Start()
    {
        player = FindObjectOfType<RobotController>();
        if(player.transform.localScale.x < 0)
        {
            bulletSpeed = -bulletSpeed;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, GetComponent<Rigidbody2D>().velocity.y);
        Destroy(gameObject, 3f);
    }
}
