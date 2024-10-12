using UnityEngine;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public CardData cardData;          // Store the reference to the card data

    // Method to initialize the card's display with CardData
    public void InitializeCard(CardData newCardData)
    {
        // Store the card data for later use
        cardData = newCardData;

        // Update the UI with the card data values
        ///cardNameText.text = cardData.cardName;
        //descriptionText.text = cardData.description;
        //healAmountText.text = "Heal: " + cardData.healAmount.ToString();

        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        
        spriteRenderer.sprite = cardData.cardArt;
    }
}
