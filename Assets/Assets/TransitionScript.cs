using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionScript : MonoBehaviour
{
    public Animator transitionAnimator;
    public string sceneToLoad;
    public Button buttonChoice; // Assign your button in the Inspector.
    public AudioSource audioSource; // Assign the AudioSource component in the Inspector.

    private void Start()
    {
        // The scene kept trying to load, so I needed to turn it off until the button was clicked.
        transitionAnimator.enabled = false;
        buttonChoice.onClick.AddListener(PlaySoundOnClick);
    }

    public void LoadSceneWithTransition()
    {
        transitionAnimator.enabled = true;
        transitionAnimator.SetTrigger("Transition");
        Invoke("LoadScene", 1.0f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    private void PlaySoundOnClick()
    
    {  
        audioSource.Play(); // Play the assigned audio clip.
    }
}