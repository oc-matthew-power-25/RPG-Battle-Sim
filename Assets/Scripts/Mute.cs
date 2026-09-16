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
        }
        else if(!isMuted)
        {
            icon.sprite = unmutedIcon;
        }
    }

    public void Toggle()
    {
        bool isMuted = PlayerPrefs.GetInt("Muted") == 1;
        if(isMuted)
        {
            icon.sprite = unmutedIcon;
            PlayerPrefs.SetInt("Muted", 0);
            PlayerPrefs.Save();
        }
        else if(!isMuted)
        {
            icon.sprite = mutedIcon;
            PlayerPrefs.SetInt("Muted", 1);
            PlayerPrefs.Save();
        }
        FindAnyObjectByType<MuteListner>().Refresh();
    }
}
