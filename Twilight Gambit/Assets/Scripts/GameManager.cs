using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Static instance for Singleton pattern
    public static GameManager Instance { get; private set; }

    public int currentEnergy; // Example variable to track current energy

    private void Awake()
    {
        // Implement Singleton pattern
        if (Instance == null)
        {
            Instance = this; // Set the instance
            DontDestroyOnLoad(gameObject); // Optional: persist through scene loads
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }

    // Example method to draw cards
    public void DrawCards(int amount)
    {
        // Implement logic to draw cards
        Debug.Log($"Draw {amount} cards.");
    }

    // Other GameManager methods...
}
