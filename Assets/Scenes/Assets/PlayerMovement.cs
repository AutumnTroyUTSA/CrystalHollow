using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    private Vector2 movement;
    private Camera mainCamera;
    private float screenPadding = 0.1f; // Adjust this value to your preference

    private void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        // Movement
        Vector2 newPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;

        // Calculate the camera's extents
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * screenAspect;

        // Define the bounds of the camera
        float xMin = mainCamera.transform.position.x - cameraWidth + screenPadding;
        float xMax = mainCamera.transform.position.x + cameraWidth - screenPadding;
        float yMin = mainCamera.transform.position.y - cameraHeight + screenPadding;
        float yMax = mainCamera.transform.position.y + cameraHeight - screenPadding;

        // Clamp the player's position within the camera bounds
        newPosition.x = Mathf.Clamp(newPosition.x, xMin, xMax);
        newPosition.y = Mathf.Clamp(newPosition.y, yMin, yMax);

        rb.MovePosition(newPosition);
    }
}