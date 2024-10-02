using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "CardData", order = 51)]
public class CardData : ScriptableObject
{
    public string cardName;        // Name of the card
    public string description;     // Card description
    public int healAmount;         // Heal amount if the card heals the player
    public int extraHeal;

    public int damageAmount;
    public int extraDamage;

    public int armorAmount;

    public int extraArmor;

    public int shieldAmount;

    public int extraShield;


    public string cardType;
    //public Sprite cardArt;         // Image representing the card

    public bool hasExtra;

    public bool extraAffectsSelf;

    // You can add more card types here if needed (damage, block, etc.)
}
