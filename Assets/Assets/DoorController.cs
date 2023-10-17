using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public int sceneBuildIndex;
    public float interactionDistance = 2.0f; // Adjust the distance to your preference
    private bool canEnter = false;
    public AudioSource audioSource; // Reference to the AudioSource component

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to this GameObject
    }

    // Update is called once per frame
    void Update()
    {
        if (canEnter && Input.GetButtonDown("Interact"))
        {
            // Play the audio clip when the player interacts
            audioSource.Play();

            // Load the specified scene
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }

    // Check for player's presence and set canEnter when they are in the interaction range.
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            float distance = Vector2.Distance(transform.position, other.transform.position);
            canEnter = distance <= interactionDistance;
        }
    }

    // Reset canEnter when the player exits the interaction range.
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canEnter = false;
        }
    }
}