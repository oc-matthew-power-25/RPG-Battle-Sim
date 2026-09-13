using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public Text healthText;
    public GameManager gameManager;
    public string species;
    public AudioClip damageSFX;

    void Start ()
    {
        healthText.text = "HP: " + currentHealth + "/" + maxHealth;
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
        if (currentHealth <= 0)
        {
            if(gameManager.turnNumber == 0)
            {
                currentHealth = 1;
                gameManager.QueueLog("But the " + species + " Survived on 1 Health.");
            }
            else
            {
                currentHealth = 0;
            }
        }
        healthText.text = "HP: " + currentHealth + "/" + maxHealth;
        
        if(currentHealth <= 0)
        {
            OnDeath();
        }
        else
        {
            GetComponent<Animator>().SetTrigger("Damaged");
            GetComponent<AudioSource>().clip = damageSFX;
            GetComponent<AudioSource>().Play();
        }
    }

    void OnDeath()
    {
        GetComponent<Animator>().SetTrigger("Death");
        gameManager.QueueLog("The " + species + " fled from the battle and returned to its habitat.");
        gameManager.QueueLog("You Won.");
        gameManager.endQueued = true;
    }
}
