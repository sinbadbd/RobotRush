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


    float maxHealth = 100;
    float currentHealth;


    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = currentHealth.ToString() + '%';
    }
}
