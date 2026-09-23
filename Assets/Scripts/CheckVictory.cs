using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckVictory : MonoBehaviour
{
    public List<String> species; 

    void Start()
    {
        if(!CheckCompleted())
        {
            PlayerPrefs.SetInt("VictoryShown", 0);
        }
        if(PlayerPrefs.GetInt("VictoryShown") != 1 && CheckCompleted())
        {
            PlayerPrefs.SetInt("VictoryShown", 1);
            SceneManager.LoadScene(11);
        }
    }

    bool CheckCompleted()
    {
        for(int i = 0; i < species.Count; i++)
        {
            if(PlayerPrefs.GetInt(species[i] + "Defeated") != 1)
            {
                return false;
            }
        }

        return true;
    }
}
