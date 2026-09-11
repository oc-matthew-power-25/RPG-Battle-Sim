using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; // Required for UI pointer events

public class UIHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Color hoverColor;
    // Triggered the exact frame the mouse enters the UI element bounding box
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Add hover logic here (e.g., change color, open tooltip)
        transform.GetChild(0).gameObject.SetActive(true);

        GetComponent<Text>().color = hoverColor;
    }

    // Triggered the exact frame the mouse leaves the UI element bounding box
    public void OnPointerExit(PointerEventData eventData)
    {
        // Add reset logic here
        transform.GetChild(0).gameObject.SetActive(false);

        GetComponent<Text>().color = Color.white;
    }
}