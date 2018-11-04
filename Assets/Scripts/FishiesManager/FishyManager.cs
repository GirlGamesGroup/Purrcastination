using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishyManager : MonoBehaviour
{
    public delegate void Fishies();
    public static event Fishies NewFish;

    public static FishyManager instance = null;

    int fishies = 0;

    int secondsRemaining = 60;

    GameObject littleClock;

    [SerializeField]
    AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);
            //PlayerPrefs.SetInt("Fishies", 0);
            //PlayerPrefs.SetInt("SecondsRemaining", 60);
            fishies = PlayerPrefs.GetInt("Fishies");
            secondsRemaining = PlayerPrefs.GetInt("SecondsRemaining");
            if (secondsRemaining == 0)
            {
                secondsRemaining = 60;
            }

            SceneManager.sceneLoaded += OnSceneLoaded;
            littleClock = transform.GetChild(0).gameObject;
            littleClock.SetActive(false);
        }
        else
            Destroy(gameObject);

       
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        StopAllCoroutines();
        littleClock.SetActive(false);
        if(scene.name.Equals("WhackARat") || scene.name.Equals("PawPaint") ||
          scene.name.Equals("Aquarium") || scene.name.Equals("TowerOfHanoi"))
        {
            StartCoroutine(PassTime());
        }
    }

    private IEnumerator PassTime()
    {
        littleClock.SetActive(true);
        littleClock.transform.rotation = Quaternion.identity;
        littleClock.transform.Rotate(new Vector3(0, 0, secondsRemaining));
        while (secondsRemaining > 0)
        {
            yield return new WaitForSeconds(1f);
            littleClock.transform.Rotate(new Vector3(0, 0, -10));
            secondsRemaining--;
            //Debug.Log(secondsRemaining);
        }
        PlayerPrefs.SetInt("Fishies", PlayerPrefs.GetInt("Fishies") + 1);
        fishies = PlayerPrefs.GetInt("Fishies");
        if(FindObjectOfType<FishyLoader>() != null)
        {
            NewFish();
        }
        secondsRemaining = 60;
        audioSource.Play();
        StartCoroutine(PassTime());
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("SecondsRemaining", secondsRemaining);
    }

}
