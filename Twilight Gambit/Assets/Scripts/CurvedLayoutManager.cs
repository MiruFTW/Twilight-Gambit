using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedLayoutManager : MonoBehaviour
{
    public Transform handTransform;
    public float radius = 10f;
    public float cardSpacing = 1f;
    public float arcAngle = 60f;

    private List<Card> cardsInHand = new List<Card>();

    public void AddCard(Card card)
    {
        cardsInHand.Add(card);
        UpdateCardPositions();
    }

    public void RemoveCard(Card card)
    {
        cardsInHand.Remove(card);
        UpdateCardPositions();
    }

    private void UpdateCardPositions()
    {
        int cardCount = cardsInHand.Count;
        float angleStep = arcAngle / (cardCount - 1);
        float startAngle = -arcAngle / 2f;

        for (int i = 0; i < cardCount; i++)
        {
            float angle = startAngle + (i * angleStep);
            float radians = angle * Mathf.Deg2Rad;
            
            Vector3 position = new Vector3(
                Mathf.Sin(radians) * radius,
                Mathf.Cos(radians) * radius,
                0f
            );

            cardsInHand[i].transform.position = handTransform.position + position;
            cardsInHand[i].transform.rotation = Quaternion.Euler(0f, 0f, -angle);
        }
    }
}

