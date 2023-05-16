using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelHandler : MonoBehaviour
{
    public bool nextLevel = true;
   

    private void OnTriggerEnter(Collider other)
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (other.gameObject.tag == "Player")
        {
            if (nextLevel)
            {
                SceneManager.LoadScene(currentScene + 1);
            }
            else
            {
                SceneManager.LoadScene(currentScene - 1);
            }
            /*if (!soundplayed)
            {
                audioSource.Play();
                soundplayed = true;
            }*/
        }
    }
}
