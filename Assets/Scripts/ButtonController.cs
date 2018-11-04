using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip btnSound;
    [SerializeField] AudioClip catSound;
    [SerializeField] AudioClip hoverSound;

    private string scene;

    public void ChangeScene(string scene)
    {
        audio.clip =  btnSound;
        audio.Play();
        this.scene = scene;
        Invoke("GoToScene",0.2f);
    }

    public void KittySound()
    {
        audio.clip = catSound;
        audio.Play();
    }

    private void GoToScene()
    {
        SceneManager.LoadScene(scene);
    }

    public void HoverSound()
    {
        audio.clip = hoverSound;
        audio.Play();
    }
}
