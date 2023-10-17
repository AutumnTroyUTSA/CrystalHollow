using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition2 : MonoBehaviour
{
    public Animator gameSceneAnimator;
    private bool hasTransitioned = false; 

    private void Start()
    {

        if (!hasTransitioned)
        {
  
            gameSceneAnimator.SetTrigger("GameSceneTransition");
            hasTransitioned = true; 
        }
    }
}