using System.Collections.Generic;
using Unity.VisualScripting;
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
                float attackMulti = (float)GetComponent<PlayerData>().attackStat / 100f;
                float enemyDefense = 1f-((float)enemyHealth.GetComponent<EnemyData>().defenseStat / 100f);
                if(activeAttackObject.type == enemyHealth.GetComponent<EnemyData>().strength)
                {
                    enemyDefense *= 0.5f;
                    gameManager.QueueLog("The " + enemyHealth.species + " is strong against " + activeAttackObject.type + " attacks.");
                }

                int damage = (int)(float)(activeAttackObject.baseDamage * attackMulti * enemyDefense);
                if(Random.Range(0,1f) <= activeAttackObject.criticalChance)
                {
                    // Critical hit
                    damage = (int)(float)(damage * criticalMultiplier);
                    gameManager.QueueLog("Critical hit! " + damage + " damage dealt.");
                    enemyHealth.RemoveHealth(damage);
                }
                else
                {
                    // Normal hit
                    gameManager.QueueLog(damage + " damage dealt.");
                    enemyHealth.RemoveHealth(damage);
                }
            }
            else
            {
                // Attack misses
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

        transform.GetComponent<AudioSource>().clip = activeAttackObject.sfx;
        GetComponent<AudioSource>().volume = 0.8f;
        GetComponent<AudioSource>().Play();
        
        gameManager.playerCanAttack = false;
    }
}
