using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerAttackObject attackObject;
    // public EnemyHealth enemyHealth;
    public float criticalMultiplier = 2f;

    public void UseAttack()
    {
        if (Random.Range(0,1f) <= attackObject.accuracy)
        {
            // Attack hits
            if(Random.Range(0,1f) <= attackObject.criticalChance)
            {
                // Critical hit
                Debug.Log("Critical hit! " + (attackObject.baseDamage * criticalMultiplier) + " damage dealt.");
                // enemyHealth.RemoveHealth(attackObject.damage * criticalMultiplier);
            }
            else
            {
                // Normal hit
                Debug.Log("Normal hit! " + attackObject.baseDamage + " damage dealt.");
                // enemyHealth.RemoveHealth(attackObject.damage);
            }
        }
        else
        {
            // Attack misses
            Debug.Log("Attack misses!");
        }
    }
}
