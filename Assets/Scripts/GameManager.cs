using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isPlayerTurn = true;
    public bool playerCanAttack = true;
    public GameObject playerAttackButtons;

    public bool isCooldown = false;
    public float cooldownLength = 1f;
    private float turnTimer = 0f;

    public Text logText;
    public float textCooldown = 0.75f;
    private float textElapsed = 0f;

    void Update()
    {
        if (isCooldown)
        {
            turnTimer += Time.deltaTime;
            if(turnTimer > cooldownLength)
            {
                if (isPlayerTurn)
                {
                    turnTimer = 0f;
                    isCooldown = false;
                    StartEnemyTurn();
                }
                else
                {
                    turnTimer = 0f;
                    isCooldown = false;
                    StartPlayerTurn();
                }
            }
        }

        if(logText.text != "")
        {
            textElapsed += Time.deltaTime;
            if(textElapsed > textCooldown)
            {
                logText.text = "";
            }
        }

        if(playerCanAttack && !playerAttackButtons.activeSelf)
        {
            playerAttackButtons.SetActive(true);
        }
        if(!playerCanAttack && playerAttackButtons.activeSelf)
        {
            playerAttackButtons.SetActive(false);
        }
    }

    public void EndPlayerTurn()
    {
        playerCanAttack = false;
        isCooldown = true;
    }

    public void EndEnemyTurn()
    {
        isCooldown = true;
    }

    public void StartPlayerTurn()
    {
        isPlayerTurn = true;
        playerCanAttack = true;
        Debug.Log("Enemy turn ended. Player's turn begins.");
    }

    public void StartEnemyTurn()
    {
        isPlayerTurn = false;
        Debug.Log("Player turn ended. Enemy's turn begins.");
        FindAnyObjectByType<EnemyAttack>().UseAttack();
    }

    public void ResetScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void UpdateLog(string text)
    {
        logText.text = text;
        textElapsed = 0f;
    }
}
