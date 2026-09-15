using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Required for UI pointer events

public class UpgradeButton : MonoBehaviour, IPointerClickHandler
{
    public bool canUpgrade = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        // Check star count
        if(canUpgrade)
        {
            UpgradeButtonParent par = transform.parent.GetComponent<UpgradeButtonParent>();
            par.level ++;
            PlayerPrefs.SetInt(par.stat + "Level", par.level);
            PlayerPrefs.Save();
            par.Refresh();
        }
    }
}
