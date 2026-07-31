using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public List<EnemyAttackObject> attackObjects;
    private EnemyAttackObject activeAttackObject;
    public PlayerHealth playerHealth;
    public float criticalMultiplier = 2f;

    public void UseAttack()
    {
        int attackIndex = Random.Range(0, attackObjects.Count);

        activeAttackObject = attackObjects[attackIndex];

        if (Random.Range(0,1f) <= activeAttackObject.accuracy)
        {
            // Attack hits
            if(Random.Range(0,1f) <= activeAttackObject.criticalChance)
            {
                // Critical hit
                Debug.Log("Critical hit! " + (activeAttackObject.baseDamage * criticalMultiplier) + " damage dealt.");
                playerHealth.RemoveHealth((int)(float)(activeAttackObject.baseDamage * criticalMultiplier));
            }
            else
            {
                // Normal hit
                Debug.Log("Normal hit! " + activeAttackObject.baseDamage + " damage dealt.");
                playerHealth.RemoveHealth(activeAttackObject.baseDamage);
            }
        }
        else
        {
            // Attack misses
            Debug.Log("Attack misses!");
        }

        FindAnyObjectByType<GameManager>().EndEnemyTurn();
    }

}
