using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool enabled;
    public float playerSpeed;
    Animator animator;
    Image characterImage;
    RectTransform rectTransform;

    void Start()
    {
        animator = GetComponent<Animator>();
        characterImage = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }

    void FixedUpdate()
    {
        if (enabled)
        {
            float input = Input.GetAxis("Horizontal");

            if (input > 0.5f)
            {
                animator.SetBool("Walk_Side", true);
                rectTransform.localScale = new Vector3(1f, 1f, 1f);
            }
            else if (input < -0.5f)
            {
                animator.SetBool("Walk_Side", true);
                rectTransform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else
            {
                animator.SetBool("Walk_Side", false);
            }

            Vector2 newPosition = rectTransform.anchoredPosition + Vector2.right * input * playerSpeed * Time.deltaTime;
            rectTransform.anchoredPosition = newPosition;
        }
    }
}