using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAttackObject", menuName = "Scriptable Objects/EnemyAttackObject")]
public class EnemyAttackObject : ScriptableObject
{
    public float accuracy = 0.95f; // 95% chance to hit
    public int baseDamage = 25;
    public float criticalChance = 0.1f; // 10% chance for critical hit
    public string type = "Melee"; // Type of attack (e.g., Melee, Ranged, Magic)
    public string attackName = "Bite";
    public string funFact = "";
}
