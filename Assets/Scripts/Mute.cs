using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    public Image icon;
    public Sprite mutedIcon;
    public Sprite unmutedIcon;

    void Start()
    {
        bool isMuted = PlayerPrefs.GetInt("Muted") == 1;
        if(isMuted)
        {
            icon.sprite = mutedIcon;
            GetComponent<Text>().text = "Unmute";
            icon.rectTransform.localPosition = new Vector3(210, 0, 0);
        }
        else if(!isMuted)
        {
            icon.sprite = unmutedIcon;
            GetComponent<Text>().text = "Mute";
            icon.rectTransform.localPosition = new Vector3(110, 0, 0);
        }
    }

    public void Toggle()
    {
        bool isMuted = PlayerPrefs.GetInt("Muted") == 1;
        if(isMuted)
        {
            icon.sprite = unmutedIcon;
            GetComponent<Text>().text = "Mute";
            icon.rectTransform.localPosition = new Vector3(110, 0, 0);
            PlayerPrefs.SetInt("Muted", 0);
            PlayerPrefs.Save();
        }
        else if(!isMuted)
        {
            icon.sprite = mutedIcon;
            GetComponent<Text>().text = "Unmute";
            icon.rectTransform.localPosition = new Vector3(210, 0, 0);
            PlayerPrefs.SetInt("Muted", 1);
            PlayerPrefs.Save();
        }
        FindAnyObjectByType<MuteListner>().Refresh();
    }
}
