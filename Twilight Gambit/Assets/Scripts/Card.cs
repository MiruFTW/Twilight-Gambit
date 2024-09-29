using UnityEngine;

public class Card : MonoBehaviour
{
    public string cardName;             // The name of the card
    public string description;     // Card description
    public int healAmount;            // Amount of health the card heals

    private Character player;          // Reference to the PlayerManager

    public CardData cardData; // Reference to CardData

    public Card(CardData data)
    {
        cardData = data;
    }

    

    void Start()
    {
        // Find the player in the scene
        player = FindObjectOfType<Character>();

        if (player == null)
        {
            Debug.LogError("PlayerManager not found in the scene!");
        }
    }

    // Method to play the card
    public void PlayCard()
    {
        if (player != null)
        {
            player.Heal(healAmount);  // Heal the player by the card's healAmount
            Debug.Log($"{cardName} played! Healed player for {healAmount}.");
        }
        
    }

    // Optional: Trigger the card effect when the card is clicked
    void OnMouseDown()
    {
        PlayCard();
    }
}
