using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public List<EnemyAttackObject> attackObjects;
    private EnemyAttackObject activeAttackObject;
    public PlayerHealth playerHealth;
    public float criticalMultiplier = 2f;
    public GameManager gameManager;

    public void UseAttack()
    {
        int attackIndex = Random.Range(0, attackObjects.Count);

        activeAttackObject = attackObjects[attackIndex];

        gameManager.QueueLog("Enemy Used " + activeAttackObject.attackName + "!");
        gameManager.QueueLog(activeAttackObject.funFact);

        if (Random.Range(0,1f) <= activeAttackObject.accuracy)
        {
            // Attack hits
            if(Random.Range(0,1f) <= activeAttackObject.criticalChance)
            {
                // Critical hit
                int damage = (int)(float)(activeAttackObject.baseDamage * criticalMultiplier);
                Debug.Log("Critical hit! " + damage + " damage dealt.");
                gameManager.QueueLog("Critical hit! " + damage + " damage dealt.");
                playerHealth.RemoveHealth(damage);
            }
            else
            {
                // Normal hit
                Debug.Log("Normal hit! " + activeAttackObject.baseDamage + " damage dealt.");
                gameManager.QueueLog("Normal hit! " + activeAttackObject.baseDamage + " damage dealt.");
                playerHealth.RemoveHealth(activeAttackObject.baseDamage);
            }
        }
        else
        {
            // Attack misses
            Debug.Log("Attack misses!");
            gameManager.QueueLog("Attack misses! 0 damage dealt.");
        }

        gameManager.EndEnemyTurn();
    }

}
