/* HealthController.cs */
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class HealthController : MonoBehaviour
{
    private bool isDead;

    private MeshRenderer meshRenderer;

    private float currentHealth;

    [SerializeField]
    private float maxHealth = 100;

    [SerializeField]
    private float respawnTime = 5;

    [SerializeField]
    private Text healthText;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void ApplyDamage(float damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
            meshRenderer.enabled = false;
            StartCoroutine(RespawnAfterTime());
        }

        UpdateHealthUI();
    }

    private void ResetHealth()
    {
        isDead = false;
        meshRenderer.enabled = true;
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    private IEnumerator RespawnAfterTime()
    {
        yield return new WaitForSeconds(respawnTime);
        ResetHealth();
    }

    private void UpdateHealthUI()
    {
        if (healthText != null) healthText.text = currentHealth + "/" + maxHealth;
    }
}
