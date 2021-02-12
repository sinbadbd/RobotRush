using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeath : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField]
    Slider healthBar;

    [SerializeField]
    Text healthText;

    [SerializeField]
    GameObject DeathUI;

    float maxHealth = 100;
    float currentHealth;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        healthBar.value = maxHealth;
        currentHealth = healthBar.value;
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Saw")
        {
            healthBar.value -= 5f;
            currentHealth = healthBar.value;
        }

        if(collision.gameObject.tag == "Acid")
        {
            healthBar.value -= 2.5f;
            currentHealth = healthBar.value;
        }
        if(collision.gameObject.tag == "Spike")
        {
            healthBar.value -= 3.5f;
            currentHealth = healthBar.value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = currentHealth.ToString() + '%';

        if(currentHealth <= 0)
        {
            anim.SetBool("isDead", true);
            GetComponent<RobotController>().enabled = false;

            DeathUI.gameObject.SetActive(true);
        }
    }
}
