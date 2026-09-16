using UnityEngine;

public class MuteListner : MonoBehaviour
{
    public bool isMuted;
    void Start ()
    {
        Refresh();
    }

    public void Refresh()
    {
        isMuted = PlayerPrefs.GetInt("Muted") == 1;
        if(isMuted) GetComponent<AudioListener>().enabled = false;
        if(!isMuted) GetComponent<AudioListener>().enabled = true;
    }
}
