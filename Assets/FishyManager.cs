using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishyManager : MonoBehaviour
{
    public static FishyManager instance = null;

    int fishies = 0;

    int secondsRemaining = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        fishies = PlayerPrefs.GetInt("Fishies");
        secondsRemaining = PlayerPrefs.GetInt("SecondsRemaining");

    }

}
