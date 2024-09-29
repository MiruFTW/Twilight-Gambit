using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject cardPrefab; // Reference to the card prefab
    public Transform cardSpawnArea; // Parent object for the spawned cards
    public int numberOfCards; // Number of cards to spawn
    public CardDatabase cardDatabase; // Reference to the card database

    private List<GameObject> spawnedCards = new List<GameObject>(); // List to track spawned cards

    public List<CardData> randomCardData = new List<CardData>();

    void Start()
    {
        SpawnCards();
    }

    // Method to spawn the cards
    public void SpawnCards()
{
    // Clear previously spawned cards (if any)
    foreach (GameObject card in spawnedCards)
    {
        Destroy(card);
    }
    spawnedCards.Clear();

    // Loop to spawn the cards
    for (int i = 0; i < numberOfCards; i++)
    {
        // Get a random card from the database
        CardData randomCardData = cardDatabase.GetRandomCard();

        // Instantiate the card prefab
        GameObject newCard = Instantiate(cardPrefab, cardSpawnArea);

        // Set the position of the card (you can modify this to create your layout)
        newCard.transform.localPosition = new Vector3((i * 2.5f) - 2.5f, 0, 0); // Spread out the cards horizontally

        // Initialize the card display
        CardDisplay cardDisplay = newCard.GetComponent<CardDisplay>();
        if (cardDisplay != null)
        {
            cardDisplay.InitializeCard(randomCardData);  // Pass the card data
        }

        // Add the new card to the list of spawned cards
        spawnedCards.Add(newCard);
    }
}

}
