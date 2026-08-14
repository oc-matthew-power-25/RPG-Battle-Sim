using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public List<PlayerAttackObject> attackObjects;
    private PlayerAttackObject activeAttackObject;
    public EnemyHealth enemyHealth;
    public float criticalMultiplier = 2f;
    public GameManager gameManager;
    public bool inAttack;

    void Update()
    {
        if(inAttack && GetComponent<Animator>().GetNextAnimatorStateInfo(0).IsName("PlayerIdle"))
        {
            if (Random.Range(0,1f) <= activeAttackObject.accuracy)
            {
                // Attack hits
                if(Random.Range(0,1f) <= activeAttackObject.criticalChance)
                {
                    // Critical hit
                    int damage = (int)(float)(activeAttackObject.baseDamage * criticalMultiplier);
                    Debug.Log("Critical hit! " + damage + " damage dealt.");
                    gameManager.QueueLog("Critical hit! " + damage + " damage dealt.");
                    enemyHealth.RemoveHealth(damage);
                }
                else
                {
                    // Normal hit
                    Debug.Log("Normal hit! " + activeAttackObject.baseDamage + " damage dealt.");
                    gameManager.QueueLog("Normal hit! " + activeAttackObject.baseDamage + " damage dealt.");
                    enemyHealth.RemoveHealth(activeAttackObject.baseDamage);
                }
            }
            else
            {
                // Attack misses
                Debug.Log("Attack misses!");
                gameManager.QueueLog("Attack misses! 0 damage dealt.");
            }

            inAttack = false;
        }
    }

    public void UseAttack(int attackIndex)
    {
        inAttack = true;

        if (attackIndex < 0 || attackIndex >= attackObjects.Count)
        {
            Debug.LogError("Invalid attack index: " + attackIndex);
            return;
        }

        if (!gameManager.playerCanAttack) return;

        activeAttackObject = attackObjects[attackIndex];

        gameManager.QueueLog("Player Used " + activeAttackObject.attackName + "!");

        GetComponent<Animator>().SetTrigger(activeAttackObject.type);
        
        gameManager.playerCanAttack = false;
    }
}
