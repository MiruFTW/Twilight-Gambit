using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardDatabase", menuName = "Card Database")]
public class CardDatabase : ScriptableObject
{
    public List<CardData> cards; // List to hold card data

    // Method to get a random card from the database
    public CardData GetRandomCard()
    {
        if (cards.Count == 0)
        {
            Debug.LogWarning("No cards in the database!");
            return null; // Return null if no cards available
        }
        
        int randomIndex = Random.Range(0, cards.Count);
        return cards[randomIndex];
    }
}
