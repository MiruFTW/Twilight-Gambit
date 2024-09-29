using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int maxHealth = 100;  // Maximum player health
    private int currentHealth;   // Current player health

    void Start()
    {
        // Initialize the player's health to max at the start
        currentHealth = 50;
        Debug.Log("Player starting health: " + currentHealth);
    }

    // Method to heal the player
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // Make sure health doesn't exceed max
        Debug.Log("Player healed. Current Health: " + currentHealth);
    }
}
