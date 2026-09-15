using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Required for UI pointer events

public class UpgradeButton : MonoBehaviour, IPointerClickHandler
{
    public bool canUpgrade = false;
    public int cost = 1;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(canUpgrade && FindAnyObjectByType<CurrentStats>().stars >= cost)
        {
            UpgradeButtonParent par = transform.parent.GetComponent<UpgradeButtonParent>();
            par.level ++;
            PlayerPrefs.SetInt(par.stat + "Level", par.level);

            PlayerPrefs.SetInt("Stars", PlayerPrefs.GetInt("Stars")-cost);

            PlayerPrefs.Save();
            par.Refresh();
            FindAnyObjectByType<CurrentStats>().Refresh();
        }
    }
}
