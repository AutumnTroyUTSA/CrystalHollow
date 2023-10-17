using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour // Rename the class to "Music" to match the script name
{
    private static Music instance; // Change "backgroundSound" to "Music" for consistency

    private void Awake()
    {
        // Check if an instance already exists. If so, destroy this one.
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // If no instance exists, mark this as the instance and prevent it from being destroyed.
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Add a scene change event handler to stop the music when a new scene is loaded.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if you're in a scene where you don't want the music to play.
        // You can use scene.name or other criteria to determine when to stop the music.
        if (scene.name == "MainMenu") // Adjust this condition to match your scene name.
        {
            StopMusic();
        }
    }

    public void PlayMusic()
    {
        // Play the music track if it's not already playing.
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    public void StopMusic()
    {
        // Stop the music.
        GetComponent<AudioSource>().Stop();
    }
}