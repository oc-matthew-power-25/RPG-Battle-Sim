using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public Text healthText;
    public GameManager gameManager;

    void Start ()
    {
        healthText.text = "HP: " + currentHealth + "/" + maxHealth;
        Time.timeScale = 1;
    }

    public void AddHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthText.text = "HP: " + currentHealth + "/" + maxHealth;
    }

    public void RemoveHealth(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        healthText.text = "HP: " + currentHealth + "/" + maxHealth;
        if (currentHealth <= 0)
        {
            OnDeath();
        }
    }

    void OnDeath()
    {
        gameManager.QueueLog("You Lost.");
        gameManager.endQueued = true;
    }
}
