using System;
using System.Collections.Generic;
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
    public List<String> textQueue;
    public float textCooldown = 0.75f;
    private float textElapsed = 0f;

    public bool endQueued = false;

    void Update()
    {
        if (isCooldown)
        {
            turnTimer += Time.deltaTime;
            if(turnTimer > cooldownLength && logText.text == "")
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

        textElapsed += Time.deltaTime;
        if(textElapsed > textCooldown)
        {
            if(textQueue.Count > 0)
            {
                logText.text = textQueue[0];
                textQueue.RemoveAt(0);
                textElapsed = 0f;

                if(textQueue.Count == 0 && endQueued)
                {
                    Time.timeScale = 0f;
                }
            }
            else
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

    public void QueueLog(string text)
    {
        textQueue.Add(text);
    }
}
