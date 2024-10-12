using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;  // Maximum player health

    public string name = "";
    public int currentHealth;   // Current player health

    public int currentShield = 0;

    public int currentArmor = 0;

    public EnemyAI enemyAI;

    private GameManager gameManager;

    //public UIDisplay UIDisplay;


    void Start()
    {
        // Initialize the player's health to max at the start
        Debug.Log("Enemy starting health: " + currentHealth);
        FindObjectOfType<UIDisplay>().DisplayEnemyHealth(currentHealth);
    }

    // Method to heal the player
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // Make sure health doesn't exceed max
        //Debug.Log("Enemy healed. Current Health: " + currentHealth);
    }
    
    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        //Debug.Log(name + " took damage. Current Health: " + currentHealth);
        FindObjectOfType<UIDisplay>().DisplayAttackMessage("Player", damageAmount);
        FindObjectOfType<UIDisplay>().DisplayEnemyHealth(currentHealth);
        //gameManager.UIDisplay.DisplayAction("Player", "Attacks", damageAmount);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void healShield(int shieldAmount)
    {
        currentShield += shieldAmount;
        currentShield = Mathf.Clamp(currentShield, 0, 25);
        //Debug.Log(name + " shield healed. Current Shield: " + currentShield);
    }

    public void damageShield(int shieldAmount)
    {
        currentShield -= shieldAmount;
        if (currentShield < 0)
        {
            currentShield = 0;
        }
        //Debug.Log(name + " shield damaged. Current Shield: " + currentShield);
    }

    public void healArmor(int armorAmount)
    {
        currentArmor += armorAmount;
        currentShield = Mathf.Clamp(currentArmor, 0, 25);
        //Debug.Log(name + " armor healed. Current Armor: " + currentArmor);
    }

    public void Die()
    {
        Debug.Log(name + " has died.");
        Destroy(this.gameObject);
        
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
}
