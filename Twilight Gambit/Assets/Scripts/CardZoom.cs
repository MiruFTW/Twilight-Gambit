    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZoom : MonoBehaviour
{
    private Vector3 originalScale;  // Store the original scale of the card
    private Vector3 targetScale;    // Target scale when zoomed in
    public float zoomAmount = 1.2f; // How much larger the card should get
    public float zoomSpeed = 5f;    // Speed of the zoom effect

    void Start()
    {
        // Store the original scale of the card when the game starts
        originalScale = transform.localScale;
        targetScale = originalScale * zoomAmount; // Define the target scale based on the zoom amount
    }

    // Coroutine to smoothly scale the card
    void OnMouseEnter()
    {
        StopAllCoroutines();
        StartCoroutine(ScaleCard(targetScale));
        transform.position = new Vector3(transform.position.x, transform.position.y, -1f); // Bring forward
    }   

    void OnMouseExit()
    {
        StopAllCoroutines();
        StartCoroutine(ScaleCard(originalScale));
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f); // Restore position
    }
    
    IEnumerator ScaleCard(Vector3 target)
    {
        while (Vector3.Distance(transform.localScale, target) > 0.01f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, target, zoomSpeed * Time.deltaTime);
            //transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 0.001f, transform.localPosition.z);

            yield return null;
        }

        transform.localScale = target; // Ensure the scale is exactly set to the target value at the end
    }

}
