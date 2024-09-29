using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 25;  // Maximum player health
    private int currentHealth;   // Current player health

    void Start()
    {
        // Initialize the player's health to max at the start
        currentHealth = maxHealth;
        Debug.Log("Enemy starting health: " + currentHealth);
    }

    // Method to heal the player
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // Make sure health doesn't exceed max
        Debug.Log("Enemy healed. Current Health: " + currentHealth);
    }
}
