using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerHealth : MonoBehaviour
{
    private static PlayerHealth _instance;
    // Start is called before the first frame update
    public int startingHealth = 100;
    public int firstAidHealing = 60;
    public float currentHealth;
    public TextMeshProUGUI lifevalue, zombieDeathCounter;
    public GameObject levelfailedBG, levelcompleteBG;
    public static int zombiecounter = 0;
    // public Image greenBar;
   // public float Life = 1;
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
        zombiecounter = 0;
    }
    private void Update()
    {
        lifevalue.text = ((int)currentHealth).ToString();
        zombieDeathCounter.text = zombiecounter.ToString();


        if (zombiecounter >= 15 && Application.loadedLevel == 1)
         {
            levelcompleteBG.SetActive(true);
            Time.timeScale = 1;
            if (!Cursor.visible || Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }

    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage * Time.deltaTime;

        if (currentHealth <= 0)
        {
            // Player is dead, end the scene
            //SceneManager.LoadScene("GameOverScene");
            // Application.Quit();
            levelfailedBG.SetActive(true);
            Time.timeScale = 1;
            if (!Cursor.visible || Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
    public void restartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 0;
    }
    public void mainmenu()
    {
        Application.LoadLevel(0);
        Time.timeScale = 0;
    }
    public void nextlevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
        Time.timeScale = 0;
    }
    public void CollectedFirstAid()
    {
        currentHealth += firstAidHealing;
        Debug.Log("Added Health");
    }

}
