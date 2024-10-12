using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CardClickHandler : MonoBehaviour
{
    private bool cardSelected = false;  // Flag to check if the card is selected

    private static bool isCardInUse = false;    // Static flag to allow only one card use at a time

    private static GameObject currentlySelectedCard = null;
    public LayerMask targetLayer;       // Layer mask to filter targets

    private CardData cardData; // Reference to the card data

    private Text cardNameText; // Reference to a Text component for the card name
    private Text cardHealAmountText; // Reference to a Text component for the heal amount

    private GameObject cardObject;

    //private Character selfCharacter;

    private GameObject playerCharacter;

    private Character selfCharacter;

    private Enemy targetEnemy;

    private Character targetCharacter;

    private GameManager gameManager;

    private UIDisplay uiDisplay;


    void Start()
    {
        GameObject gameManagerObj = GameObject.FindGameObjectWithTag("GameController");
        gameManager = gameManagerObj.GetComponent<GameManager>();

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

                if (selectedObject.tag == "Card")
                {
                    DeselectCard();
                    return;
                }

                if (cardData.cardType == "Attack")
                {
                    targetEnemy = selectedObject.GetComponent<Enemy>();
                }
                else
                {
                    targetCharacter = selectedObject.GetComponent<Character>();
                }

                if (selectedObject == null)
                {
                    Debug.LogError("Selected Object is null.");
                }

                if (targetCharacter == null && targetEnemy == null)
                {
                    Debug.LogError("Target Character and Target Enemy is null.");
                }

                playerCharacter = GameObject.FindGameObjectWithTag("Player");
                selfCharacter = playerCharacter.GetComponent<Character>();
                

                if (targetEnemy != null || targetCharacter != null)
                {
                    
                    // Apply heal to the clicked target
                    /*if (cardData.cardType == "Heal")
                    {
                        targetCharacter.Heal(cardData.healAmount);
                    }
                    else if (cardData.cardType == "Attack")
                    {
                        targetEnemy.Damage(cardData.damageAmount);
                    }
                    else if (cardData.cardType == "Shield")
                    {
                        targetCharacter.healShield(cardData.shieldAmount);
                    }
                    else if (cardData.cardType == "Armor")
                    {
                        targetCharacter.healArmor(cardData.armorAmount);
                    }*/

                    switch(cardData.cardType)
                    {
                        case "Heal":
                            targetCharacter.Heal(cardData.healAmount);
                            break;
                        case "Attack":
                            targetEnemy.Damage(cardData.damageAmount);
                            break;
                        case "Shield":
                            targetCharacter.healShield(cardData.shieldAmount);
                            break;
                        case "Armor":
                            targetCharacter.healArmor(cardData.armorAmount);
                            break;
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
                                targetEnemy.Heal(cardData.extraHeal);
                            }
                            else
                            {
                                targetEnemy.Damage(cardData.extraDamage);
                            }
                        }
                    }
                    
                    DeselectCard();
                    gameManager.UseEnergy(1);
                    Destroy(cardObject);
                    Debug.Log(cardObject);

                    Debug.Log(gameManager.playerEnergyPerTurn + " " + gameManager.currentEnergy);

                    // End turn if out of energy
                    if (gameManager.currentEnergy == 0)
                    {
                        gameManager.EndTurn();
                    }
                }
            }
        }
    }


    // This method is called when the card is clicked
    public void OnCardClick()
    {

        GameObject buttonObject = gameObject;
        GameObject parentObject = buttonObject.transform.parent.gameObject;
        cardObject = parentObject.transform.parent.gameObject;

        if (isCardInUse && currentlySelectedCard == cardObject)
        {
            Debug.Log("Deselecting current card.");
            DeselectCard();
        }
        else
        {

            Debug.Log("Card selected. Click on a target.\n");

            CardDisplay cardDisplay = cardObject.GetComponent<CardDisplay>();
            cardData = cardDisplay.cardData; 

            Debug.Log(cardData.name + "\n" + cardData.cardType);
        
            cardSelected = true;  // Mark the card as selected
            isCardInUse = true;  
            currentlySelectedCard = cardObject;
            Debug.Log(currentlySelectedCard);
        }


    }

    public void DeselectCard()
    {
        cardSelected = false;
        isCardInUse = false;
        currentlySelectedCard = null;
        Debug.Log("Card deselected.");
    }
}
