using UnityEngine;
using UnityEngine.UI;

public class CardClickHandler : MonoBehaviour
{
    private bool cardSelected = false;  // Flag to check if the card is selected

    private static bool isCardInUse = false;    // Static flag to allow only one card use at a time
    public LayerMask targetLayer;       // Layer mask to filter targets

    private CardData cardData; // Reference to the card data

    private Text cardNameText; // Reference to a Text component for the card name
    private Text cardHealAmountText; // Reference to a Text component for the heal amount

    private GameObject cardObject;

    //private Character selfCharacter;

    private GameObject playerCharacter;

    private Character selfCharacter;

    private int userHealth;

    void Start()
    {

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
                GameObject selectedObject = hit.collider.gameObject;
                Character targetCharacter = selectedObject.GetComponent<Character>();

                if (selectedObject == null)
                {
                    Debug.LogError("Selected Object is null.");
                }

                if (targetCharacter == null)
                {
                    Debug.LogError("Target Character is null.");
                }

                if (selectedObject.CompareTag("Enemy"))
                {
                    playerCharacter = GameObject.FindGameObjectWithTag("Player");
                    selfCharacter = playerCharacter.GetComponent<Character>();
                }
                else
                {
                    GameObject enemyObject = GameObject.FindGameObjectWithTag("Enemy");
                    selfCharacter = enemyObject.GetComponent<Character>();
                }

                if (selfCharacter == null)
                {
                    Debug.LogError("Self character is null.");
                }
                

                if (targetCharacter != null)
                {
                    
                    // Apply heal to the clicked target
                    if (cardData.cardType == "Heal")
                    {
                        targetCharacter.Heal(cardData.healAmount);
                    }
                    else if (cardData.cardType == "Attack")
                    {
                        targetCharacter.Damage(cardData.damageAmount);
                    }
                    else if (cardData.cardType == "Shield")
                    {
                        targetCharacter.healShield(cardData.shieldAmount);
                    }
                    else if (cardData.cardType == "Armor")
                    {
                        targetCharacter.healArmor(cardData.armorAmount);
                    }
                    
                    if (cardData.hasExtra)
                    {
                        if (cardData.extraAffectsSelf)
                        {
                            
                            if (cardData.extraHeal != 0)
                            {
                                selfCharacter.Heal(cardData.extraHeal);
                            }
                            else
                            {
                                selfCharacter.Damage(cardData.extraDamage);
                            }
                        }
                        else
                        {
                            if (cardData.extraHeal != 0)
                            {
                                targetCharacter.Heal(cardData.extraHeal);
                            }
                            else
                            {
                                targetCharacter.Damage(cardData.extraDamage);
                            }
                        }
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

        Debug.Log("Card selected. Click on a target.\n");
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
