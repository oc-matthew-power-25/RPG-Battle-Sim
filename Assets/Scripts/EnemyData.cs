using UnityEngine;

public class EnemyData : MonoBehaviour
{
    [Range(1,100)]
    public int attackStat = 65;
    [Range(1,100)]
    public int defenseStat = 60;
    public string strength = "Melee";
    public int stars;
}

