
using UnityEngine;

public class healthPickUp : MonoBehaviour
{
    public PlayerHeath playerHealth;
    public float healthBonus = 15f;

     void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHeath>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        print("health");
        if (playerHealth.currentHealth < playerHealth.maxHealth)
        {
            Destroy(gameObject);
            playerHealth.currentHealth = playerHealth.currentHealth + healthBonus;
        }
    }
}
