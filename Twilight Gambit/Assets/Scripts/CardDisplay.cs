using UnityEngine;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public TMP_Text cardNameText;      // UI element to display card name
    public TMP_Text descriptionText;   // UI element to display card description
    public TMP_Text healAmountText;    // UI element to display heal amount

    public CardData cardData;          // Store the reference to the card data

    // Method to initialize the card's display with CardData
    public void InitializeCard(CardData newCardData)
    {
        // Store the card data for later use
        cardData = newCardData;

        // Update the UI with the card data values
        cardNameText.text = cardData.cardName;
        descriptionText.text = cardData.description;
        healAmountText.text = "Heal: " + cardData.healAmount.ToString();
    }
}
