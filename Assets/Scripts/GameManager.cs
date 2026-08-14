using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isPlayerTurn = true;
    public bool playerCanAttack = true;
    public GameObject playerAttackButtons;

    public Text logText;
    public List<String> textQueue;
    public bool endQueued = false;
    private bool isEnd;

    void Update()
    {

        if(logText.text == "" && textQueue.Count > 0)
        {
                logText.transform.GetChild(0).gameObject.SetActive(true);
            logText.text = textQueue[0];
            textQueue.RemoveAt(0);
        }

        if(logText.text == "" && textQueue.Count <= 0)
        {
            logText.transform.GetChild(0).gameObject.SetActive(false);
            if (isPlayerTurn && !playerCanAttack && FindAnyObjectByType<PlayerAttack>().inAttack == false && FindAnyObjectByType<EnemyAttack>().inAttack == false)
            {
                StartEnemyTurn();
            }
            else if(FindAnyObjectByType<PlayerAttack>().inAttack == false && FindAnyObjectByType<EnemyAttack>().inAttack == false)
            {
                StartPlayerTurn();
            }
        }

        if((Keyboard.current.spaceKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame) && !isEnd)
        {
            if(textQueue.Count > 0)
            {
                logText.text = textQueue[0];
                textQueue.RemoveAt(0);

                if(textQueue.Count == 0 && endQueued)
                {
                    Time.timeScale = 0f;
                    logText.transform.GetChild(0).gameObject.SetActive(false);
                    isEnd = true;
                }
            }
            else
            {
                logText.text = "";
            }
        }

        if(playerCanAttack && !playerAttackButtons.activeSelf && FindAnyObjectByType<PlayerAttack>().inAttack == false && FindAnyObjectByType<EnemyAttack>().inAttack == false)
        {
            playerAttackButtons.SetActive(true);
        }
        if(!playerCanAttack && playerAttackButtons.activeSelf)
        {
            playerAttackButtons.SetActive(false);
        }
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
