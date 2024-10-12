using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject cardPrefab; // Reference to the card prefab
    public Transform cardSpawnArea; // Parent object for the spawned cards
    public CardDatabase cardDatabase; // Reference to the card database

    private List<GameObject> spawnedCards = new List<GameObject>(); // List to track spawned cards

    public List<CardData> randomCardData = new List<CardData>();

    // Method to spawn the cards in hand
    public void SpawnCards(List<CardData> cardsToSpawn)
    {
        // Clear previously spawned cards (if any)
        foreach (GameObject card in spawnedCards)
        {
            Destroy(card);
        }
        spawnedCards.Clear();

        // Loop to spawn the cards based on the provided list
        for (int i = 0; i < cardsToSpawn.Count; i++)
        {
            // Get the card data from the provided list
            CardData cardData = cardsToSpawn[i];


            // Instantiate the card prefab
            GameObject newCard = Instantiate(cardPrefab, cardSpawnArea);

            // Set a unique name for the card (e.g., "Card_1", "Card_2", etc.)
            //newCard.name = "Card_" + i;

            // Set the position of the card dynamically (you can modify this to create your layout)
            newCard.transform.localPosition = new Vector3((i * 2.5f) - 2.5f, 0, 0); // Spread out the cards horizontally

            // Initialize the card display
            CardDisplay cardDisplay = newCard.GetComponent<CardDisplay>();
            if (cardDisplay != null)
            {
                cardDisplay.InitializeCard(cardData);  // Pass the card data

                SpriteRenderer spriteRenderer = newCard.GetComponentInChildren<SpriteRenderer>();

                if (spriteRenderer != null && cardData.cardArt != null)
                {
                    spriteRenderer.sprite = cardData.cardArt;
                }
            }

            // Add the new card to the list of spawned cards
            spawnedCards.Add(newCard);
        }
    }

    public void DeleteCard(GameObject cardObject)
    {
        Destroy(cardObject);
    }
    

    // Method to get a random card from the database
    public CardData GetRandomCard()
    {
        return cardDatabase.GetRandomCard();
    }
}
