using UnityEngine;
using UnityEngine.UI;

public class CardClickHandler : MonoBehaviour
{
    private bool cardSelected = false;  // Flag to check if the card is selected

    private static bool isCardInUse = false;    // Static flag to allow only one card use at a time
    public LayerMask targetLayer;       // Layer mask to filter targets

    private CardData cardData; // Reference to the card data

    public CardDatabase cardDatabase;

    private Text cardNameText; // Reference to a Text component for the card name
    private Text cardHealAmountText; // Reference to a Text component for the heal amount

    private GameObject cardObject;

    void Start()
    {
        
        //Debug.Log(cardData.name + "\n" + cardData.healAmount);
    }


    void Update()
    {
        // Check if the card is selected and the user clicks the mouse
        if (cardSelected && Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, targetLayer);

            if (hit.collider != null)
            {
                Character targetCharacter = hit.collider.GetComponent<Character>();

                if (targetCharacter != null)
                {
                    // Apply heal to the clicked target

                    if (cardData.cardType == "Heal")
                    {
                        targetCharacter.Heal(cardData.healAmount);
                        Debug.Log($"{targetCharacter.name} Healed for " + cardData.healAmount + " HP!");
                    }
                    else if (cardData.cardType == "Damage")
                    {
                        targetCharacter.Damage(cardData.damageAmount);
                        Debug.Log($"{targetCharacter.name} Damaged for " + cardData.damageAmount + " HP!");
                    }

                    // Deselect the card after healing
                    cardSelected = false;
                    isCardInUse = false;
                }
            }
        }
    }


    // This method is called when the card is clicked
    public void OnCardClick()
    {

        if (isCardInUse)
        {
            Debug.Log("A card is already in use. Please complete the current action before selecting another card.");
            return; // If a card is already in use, don't allow selection of another card
        }

        Debug.Log("Card selected. Click on a target to heal.\n");
        GameObject buttonObject = gameObject;
        GameObject parentObject = buttonObject.transform.parent.gameObject;
        cardObject = parentObject.transform.parent.gameObject;
        
        CardDisplay cardDisplay = cardObject.GetComponent<CardDisplay>();
        cardData = cardDisplay.cardData;
        Debug.Log(cardData.name + "\n" + cardData.cardType);
        
        
        cardSelected = true;  // Mark the card as selected
        isCardInUse = true;
    }
}
