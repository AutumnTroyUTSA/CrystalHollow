using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class createClick : MonoBehaviour
{
    public Button switchButton; // Assign your button in the Inspector.
    public string sceneToLoad; // Name of the scene to switch to.
    public AudioSource buttonClickSound; // Assign the AudioSource component in the Inspector.

    private void Start()
    {
        // Add a listener to the button's click event.
        switchButton.onClick.AddListener(PlaySoundOnClick);
    }

    private void PlaySoundOnClick()
    {
        // Play the button click sound.
        buttonClickSound.Play();

        // Start a coroutine to delay loading the scene.
        StartCoroutine(LoadSceneWithDelay());
    }

    private IEnumerator LoadSceneWithDelay()
    {
        // Wait for a specific duration (e.g., 1 second) before loading the scene.
        yield return new WaitForSeconds(1.0f); // Adjust the duration as needed.

        // Switch to the specified scene.
        SceneManager.LoadScene(sceneToLoad);
    }
}