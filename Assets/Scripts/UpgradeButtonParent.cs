using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonParent : MonoBehaviour
{
    public string stat;

    public int level;

    void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        level = PlayerPrefs.GetInt(stat + "Level");
        if(level < 0) level = 0;
        if(level > 5) level = 5;

        for(int i = 0; i < 5; i++)
        {
            if(i < level)
            {
                // Unable to upgrade
                transform.GetChild(i).GetComponent<Image>().color = Color.black;
                transform.GetChild(i).GetComponent<UpgradeButton>().canUpgrade = false;
            }
            if(i == level)
            {
                // Able to upgrade
                transform.GetChild(i).GetComponent<Image>().color = Color.white;
                transform.GetChild(i).GetComponent<UpgradeButton>().canUpgrade = true;
            }
            if(i > level)
            {
                // Future upgrade
                transform.GetChild(i).GetComponent<Image>().color = Color.grey;
                transform.GetChild(i).GetComponent<UpgradeButton>().canUpgrade = false;
            }
        }
    }
}
