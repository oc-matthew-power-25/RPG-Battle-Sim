using UnityEngine;

public class DefeatedIcon : MonoBehaviour
{
    public string species;
    public bool defeated;
    public GameObject tick;
    public GameObject cross;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        defeated = PlayerPrefs.GetInt(species + "Defeated") == 1;

        if(defeated) Destroy(cross);
        else Destroy(tick);
    }
}
