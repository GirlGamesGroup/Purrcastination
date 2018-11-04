using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishyManager : MonoBehaviour
{
    public static FishyManager instance = null;

    int fishies = 0;

    int secondsRemaining = 180;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);

            fishies = PlayerPrefs.GetInt("Fishies");
            secondsRemaining = PlayerPrefs.GetInt("SecondsRemaining");
            if (secondsRemaining == 0)
            {
                secondsRemaining = 180;
            }

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
            Destroy(gameObject);

       
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        StopAllCoroutines();
        if(scene.name.Equals("WhackARat") || scene.name.Equals("PawPaint") ||
          scene.name.Equals("Aquarium") || scene.name.Equals("TowerOfHanoi"))
        {
            StartCoroutine(PassTime());
        }
    }

    private IEnumerator PassTime()
    {
        while(secondsRemaining > 0)
        {
            yield return new WaitForSeconds(1f);
            secondsRemaining--;
            Debug.Log(secondsRemaining);
        }
        fishies++;
        PlayerPrefs.SetInt("Fishies", fishies);
        secondsRemaining = 180;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("SecondsRemaining", secondsRemaining);
    }

}
