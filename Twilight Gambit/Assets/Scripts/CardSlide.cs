using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlide : MonoBehaviour
{
    private Vector3 originalPosition; // Store the original position of the card
    private Vector3 targetPosition;   // Target position when sliding up
    public float slideAmount = 2f;    // How much the card should slide up
    public float slideSpeed = 5f;     // Speed of the sliding effect

    private bool alreadyClick = false;

    void Start()
    {
        // Store the original position of the card when the game starts
        originalPosition = transform.localPosition;
        targetPosition = new Vector3(originalPosition.x, originalPosition.y + slideAmount, originalPosition.z); // Define the target position by sliding up
    }

    // Coroutine to smoothly move the card up
    void OnMouseDown()
    {
        alreadyClick = !alreadyClick;
        
        if (alreadyClick == false)
        {
            StopAllCoroutines();
            StartCoroutine(SlideCard(targetPosition)); // Slide up
            transform.position = new Vector3(transform.position.x, transform.position.y, -1f); // Bring forward
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(SlideCard(originalPosition)); // Slide back to original position
            transform.position = new Vector3(transform.position.x, transform.position.y, 0f); // Restore position
        }
    }

    IEnumerator SlideCard(Vector3 target)
    {
        while (Vector3.Distance(transform.localPosition, target) > 0.01f)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, target, slideSpeed * Time.deltaTime);
            yield return null;
        }

        transform.localPosition = target; // Ensure the position is exactly set to the target value at the end
        
    }
}
