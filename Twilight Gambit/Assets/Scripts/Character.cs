using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public int maxHealth = 100;  // Maximum player health

    public string name = "";
    public int currentHealth;   // Current player health

    void Start()
    {
        // Initialize the player's health to max at the start
        Debug.Log("Player starting health: " + currentHealth);
    }

    // Method to heal the player
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // Make sure health doesn't exceed max
        Debug.Log("Player healed. Current Health: " + currentHealth);
    }
    
    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log(name + " took damage. Current Health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Debug.Log(name + " has died.");
        Destroy(this.gameObject);
        
    }
}
