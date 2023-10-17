using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Unity.UI;

public class mouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Animator spriteAnimator; // Reference to the Animator component.

    private void Start()
    {
        // Disable the animator by default.
        spriteAnimator.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // When the mouse hovers over the sprite.
        spriteAnimator.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // When the mouse exits the sprite.
        spriteAnimator.enabled = false;
    }
}