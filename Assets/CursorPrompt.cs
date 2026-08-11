using UnityEngine;

public class CursorPrompt : MonoBehaviour
{
    public float interval = 0.25f;
    void Update()
    {
        if((int)(Time.time * 1/interval) % 2 == 0)
        {
            GetComponent<UnityEngine.UI.Image>().enabled = false;
        } else
        {
            GetComponent<UnityEngine.UI.Image>().enabled = true;
        }
    }
}
