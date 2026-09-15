using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [Range(1,100)]
    public int attackStat = 65;
    [Range(1,100)]
    public int defenseStat = 60;

    void Start()
    {
        int attackLevel = PlayerPrefs.GetInt("AttackLevel");
        int hpLevel = PlayerPrefs.GetInt("HPLevel");
        int defenseLevel = PlayerPrefs.GetInt("DefenseLevel");

        if(attackLevel == 0)attackStat = 65;
        if(attackLevel == 1)attackStat = 70;
        if(attackLevel == 2)attackStat = 75;
        if(attackLevel == 3)attackStat = 80;
        if(attackLevel == 4)attackStat = 90;
        if(attackLevel == 5)attackStat = 100;

        int hp = 100;

        if(hpLevel == 0)hp = 100;
        if(hpLevel == 1)hp = 110;
        if(hpLevel == 2)hp = 120;
        if(hpLevel == 3)hp = 130;
        if(hpLevel == 4)hp = 140;
        if(hpLevel == 5)hp = 150;

        GetComponent<PlayerHealth>().maxHealth = hp;
        GetComponent<PlayerHealth>().currentHealth = hp;

        if(defenseLevel == 0)defenseStat = 50;
        if(defenseLevel == 1)defenseStat = 55;
        if(defenseLevel == 2)defenseStat = 60;
        if(defenseLevel == 3)defenseStat = 65;
        if(defenseLevel == 4)defenseStat = 70;
        if(defenseLevel == 5)defenseStat = 80;

        GetComponent<PlayerHealth>().healthText.text = "HP: " + hp + "/" + hp;
    }
}
