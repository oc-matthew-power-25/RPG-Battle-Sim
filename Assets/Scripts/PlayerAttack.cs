using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public List<PlayerAttackObject> attackObjects;
    private PlayerAttackObject activeAttackObject;
    public EnemyHealth enemyHealth;
    public float criticalMultiplier = 2f;

    public void UseAttack(int attackIndex)
    {
        if (attackIndex < 0 || attackIndex >= attackObjects.Count)
        {
            Debug.LogError("Invalid attack index: " + attackIndex);
            return;
        }

        activeAttackObject = attackObjects[attackIndex];

        if (Random.Range(0,1f) <= activeAttackObject.accuracy)
        {
            // Attack hits
            if(Random.Range(0,1f) <= activeAttackObject.criticalChance)
            {
                // Critical hit
                Debug.Log("Critical hit! " + (activeAttackObject.baseDamage * criticalMultiplier) + " damage dealt.");
                enemyHealth.RemoveHealth((int)(float)(activeAttackObject.baseDamage * criticalMultiplier));
            }
            else
            {
                // Normal hit
                Debug.Log("Normal hit! " + activeAttackObject.baseDamage + " damage dealt.");
                enemyHealth.RemoveHealth(activeAttackObject.baseDamage);
            }
        }
        else
        {
            // Attack misses
            Debug.Log("Attack misses!");
        }

        FindAnyObjectByType<GameManager>().EndPlayerTurn();
    }
}
