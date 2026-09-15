using UnityEngine;
using UnityEngine.UI;

public class CurrentStats : MonoBehaviour
{
    public int attackLevel;
    public int hpLevel;
    public int defenseLevel;

    public int attack;
    public int hp;
    public int defense;

    public Text attackText;
    public Text hpText;
    public Text defenseText;

    void Start()
    {
        attackLevel = PlayerPrefs.GetInt("AttackLevel");
        hpLevel = PlayerPrefs.GetInt("HPLevel");
        defenseLevel = PlayerPrefs.GetInt("DefenseLevel");

        if(attackLevel == 0)attack = 65;
        if(attackLevel == 1)attack = 70;
        if(attackLevel == 2)attack = 75;
        if(attackLevel == 3)attack = 80;
        if(attackLevel == 4)attack = 90;
        if(attackLevel == 5)attack = 100;

        if(hpLevel == 0)hp = 100;
        if(hpLevel == 1)hp = 110;
        if(hpLevel == 2)hp = 120;
        if(hpLevel == 3)hp = 130;
        if(hpLevel == 4)hp = 140;
        if(hpLevel == 5)hp = 150;

        if(defenseLevel == 0)defense = 50;
        if(defenseLevel == 1)defense = 55;
        if(defenseLevel == 2)defense = 60;
        if(defenseLevel == 3)defense = 65;
        if(defenseLevel == 4)defense = 70;
        if(defenseLevel == 5)defense = 80;

        attackText.text = attack.ToString();
        hpText.text = hp.ToString();
        defenseText.text = defense.ToString();
    }
}
