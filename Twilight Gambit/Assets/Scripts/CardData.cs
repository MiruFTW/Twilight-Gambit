using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "CardData", order = 51)]
public class CardData : ScriptableObject
{
    public string cardName;        // Name of the card
    public string description;     // Card description
    public int healAmount;         // Heal amount if the card heals the player

    public int damageAmount;

    public string cardType;
    //public Sprite cardArt;         // Image representing the card

    // You can add more card types here if needed (damage, block, etc.)
}
