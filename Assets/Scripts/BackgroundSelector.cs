using System.Collections.Generic;
using UnityEngine;

public class BackgroundSelector : MonoBehaviour
{
    public List<Sprite> backgrounds;

    void Start()
    {
        Randomise();   
    }

    [ContextMenu ("Randomise")]
    void Randomise()
    {
        GetComponent<SpriteRenderer>().sprite = backgrounds[Random.Range(0, backgrounds.Count)];
    }
}
