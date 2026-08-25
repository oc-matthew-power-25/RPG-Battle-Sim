using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public List<EnemyAttackObject> attackObjects;
    public List<bool> factsSaid;
    private EnemyAttackObject activeAttackObject;
    public PlayerHealth playerHealth;
    public float criticalMultiplier = 2f;
    public GameManager gameManager;
    public bool inAttack;
    private bool attackAnimationStarted;


    void Start()
    {
        for (int i = 0; i < attackObjects.Count; i++)
        {
            factsSaid.Add(false);
        }
    }
    
    void Update()
    {    
        AnimatorStateInfo state = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);

        if (inAttack)
        {
            // Wait until we actually enter the attack animation
            if (!state.IsName("Idle") && !state.IsName("Damaged"))
            {
                attackAnimationStarted = true;
            }

            // Once the attack animation has finished and we're back to Idle
            if (attackAnimationStarted && state.IsName("Idle"))
            {
                DealDamage();

                inAttack = false;
                attackAnimationStarted = false;
            }
        }
    }

    public void UseAttack()
    {

        inAttack = true; 

        int attackIndex = Random.Range(0, attackObjects.Count);

        activeAttackObject = attackObjects[attackIndex];

        gameManager.QueueLog("Enemy Used " + activeAttackObject.attackName + "!");
        if(!factsSaid[attackIndex]){
            gameManager.QueueLog(activeAttackObject.funFact);
            factsSaid[attackIndex] = true;
        }

        GetComponent<Animator>().SetTrigger(activeAttackObject.type);
    }

    private void DealDamage()
    {
        if (Random.Range(0,1f) <= activeAttackObject.accuracy)
        {
            // Attack hits
            float attackMulti = (float)GetComponent<EnemyData>().attackStat / 100f;
            float enemyDefense = 1f-((float)playerHealth.GetComponent<PlayerData>().defenseStat / 100f);
            int damage = (int)(float)(activeAttackObject.baseDamage * attackMulti * enemyDefense);
            if(Random.Range(0,1f) <= activeAttackObject.criticalChance)
            {
                // Critical hit
                damage = (int)(float)(damage * criticalMultiplier);
                gameManager.QueueLog("Critical hit! " + damage + " damage dealt.");
                playerHealth.RemoveHealth(damage);
            }
            else
            {
                // Normal hit
                gameManager.QueueLog(damage + " damage dealt.");
                playerHealth.RemoveHealth(damage);
            }
        }
        else
        {
            // Attack misses
            Debug.Log("Attack misses!");
            gameManager.QueueLog("Attack misses! 0 damage dealt.");
        }
    }

}
