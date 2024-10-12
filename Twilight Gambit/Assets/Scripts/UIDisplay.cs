using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class UIDisplay : MonoBehaviour
{
    public TextMeshProUGUI combatText; // Reference to the TextMeshProUGUI component

    public TextMeshProUGUI playerHealthText;

    public TextMeshProUGUI enemyHealthText;


    // Method to display combat message
    public void DisplayAttackMessage(string userName, int damageAmount)
    {
        combatText.text = $"{userName} attacks for {damageAmount} damage!";
        StartCoroutine(HideTextAfterDelay());
    }

    public void DisplayEnemyHealth(int currentHealth)
    {
        enemyHealthText.text = $"Enemy: {currentHealth} HP";
    }

    public void DisplayPlayerHealth(int currentHealth)
    {
        playerHealthText.text = $"Player: {currentHealth} HP";
    }

    // Optional: Hide the text after a few seconds
    private IEnumerator HideTextAfterDelay()
    {
        yield return new WaitForSeconds(2f); // Wait for 2 seconds
        combatText.text = ""; // Clear the message
    }
}
