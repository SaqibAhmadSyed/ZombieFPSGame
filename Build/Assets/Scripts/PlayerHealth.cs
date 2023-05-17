using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private static PlayerHealth _instance;
    // Start is called before the first frame update
    public int startingHealth = 100;
    public int firstAidHealing = 60;
    public int currentHealth;

    public static PlayerHealth Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlayerHealth();
            }

            return _instance;
        }
    }

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;


        /*if (zombiecounter >= 15 && Application.loadedLevel == 1)
         {
            levelcompleteBG.SetActive(true);
            Time.timeScale = 1;
            if (!Cursor.visible || Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }/*/

    }
/*    public void TakeDamage(int damage)
    {
        currentHealth -= damage * Time.deltaTime;

       
        
        if (currentHealth <= 0)
        {
            // Player is dead, end the scene
            //SceneManager.LoadScene("GameOverScene");
            Application.Quit();
        }
    }*/

    public void CollectedFirstAid()
    {
        if ((currentHealth >= (startingHealth - firstAidHealing)))
        {
            currentHealth = startingHealth;
        }
        else
        {
           currentHealth += firstAidHealing;
        }
        
        Debug.Log("Added Health");
    }

}
