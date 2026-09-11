using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Required for UI pointer events

public class OnClick : MonoBehaviour, IPointerClickHandler
{
    public int nextScene;
    public bool exitGame = false;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(exitGame)
        {
            Application.Quit();
        }
        else{
            SceneManager.LoadScene(nextScene);
        }
    }
}
