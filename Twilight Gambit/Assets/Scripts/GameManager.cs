using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalRounds = 10;     // Total rounds in the game
    public int playerEnergyPerTurn = 3; // How much energy the player has per turn
    public int currentRound = 1;     // Tracks the current round
    public int currentTurn = 1;      // Tracks the current turn
    public int maxHandSize = 5;      // Maximum cards drawn at start of fight
    public int cardsPerTurn = 1;     // Cards drawn each turn

    public int currentEnergy;       // Energy available in the current turn

    public CardManager cardManager;  // Reference to the card manager (for spawning cards)
    
    private List<CardData> playerHand = new List<CardData>(); // The player's current hand of cards

    private EnemyAI enemyAI;
    private GameObject enemyObj;

    private Enemy enemy;


    public int cardsUsed = 0;

    void Start()
    {
        StartFight();

    }


    // Initialize fight, reset turn/round and draw starting hand
    void StartFight()
    {
        currentRound = 1;
        currentTurn = 1;
        currentEnergy = playerEnergyPerTurn;

        Debug.Log(currentRound);

        enemyObj = GameObject.FindGameObjectWithTag("Enemy");
        enemyAI = enemyObj.GetComponent<EnemyAI>();
        enemy = enemyObj.GetComponent<Enemy>();


        DrawNewHand();
    }

    // Draw 5 cards at the start of the fight
    void DrawNewHand()
    {
        playerHand.Clear();
        for (int i = 0; i < maxHandSize; i++)
        {
            DrawCard();
        }
        cardManager.SpawnCards(playerHand);  // Spawn the initial hand using CardManager
        Debug.Log("Starting hand drawn. Cards in hand: " + playerHand.Count);
    }

    // Method to draw a card
    void DrawCard()
    {
        CardData drawnCard = cardManager.GetRandomCard();
        playerHand.Add(drawnCard);
        Debug.Log("Card drawn: " + drawnCard.name);
    }

    // Method to start a new turn
    public void StartTurn()
    {
        currentEnergy = playerEnergyPerTurn; // Reset energy
        currentTurn++;
        //DrawCard(); // Draw one card at the start of the turn
        playerHand.Clear();
        DrawNewHand();
        //cardManager.SpawnCards(playerHand); // Update the hand with new card drawn
        Debug.Log("New turn started. Turn: " + currentTurn + ", Energy: " + currentEnergy);
    }

    // Method to use energy when playing a card
    public bool UseEnergy(int amount)
    {
        if (currentEnergy >= amount)
        {
            currentEnergy -= amount;
            Debug.Log("Used " + amount + " energy. Remaining energy: " + currentEnergy);
            return true;
        }
        else
        {
            Debug.Log("Not enough energy!");
            return false;
        }
    }

    // Method to end the turn and check for round end
    public void EndTurn()
    {
        Debug.Log("Turn ended.");
        enemyAI.AttackPlayer(10);
        if (currentTurn >= totalRounds)
        {
            EndRound();
        }
        else
        {
            StartTurn();
        }
    }

    // Method to handle the end of a round
    void EndRound()
    {
        currentRound++;
        currentTurn = 1;  // Reset turns for the next round
        if (currentRound > totalRounds)
        {
            EndGame();
        }
        else
        {
            Debug.Log("Round " + currentRound + " started.");
            StartTurn();
        }
    }

    // End the game
    void EndGame()
    {
        Debug.Log("Game Over!");
        // Add game over logic here (victory, defeat, etc.)
    }
}
