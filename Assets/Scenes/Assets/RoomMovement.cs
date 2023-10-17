using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float roomMinX;
    public float roomMaxX;
    public float roomMinY;
    public float roomMaxY;
    public float exitMinX;
    public float exitMaxX;
    public float exitMinY;
    public float exitMaxY;

    public Rigidbody2D rb;
    public Animator animator;
    
    private Camera mainCamera;
    private float screenPadding = 0.1f;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // Input
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        // Movement
        Vector2 newPosition = rb.position + (moveSpeed * Time.fixedDeltaTime) * new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

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

        // Check if the new position is within either rectangle (room or exit area)
        if (IsWithinRoom(newPosition) || IsWithinExitArea(newPosition))
        {
            rb.MovePosition(newPosition);
        }
    }

    // Helper functions to check if a position is within a rectangle
    private bool IsWithinRoom(Vector2 position)
    {
        return position.x >= roomMinX && position.x <= roomMaxX && position.y >= roomMinY && position.y <= roomMaxY;
    }

    private bool IsWithinExitArea(Vector2 position)
    {
        return position.x >= exitMinX && position.x <= exitMaxX && position.y >= exitMinY && position.y <= exitMaxY;
    }
}