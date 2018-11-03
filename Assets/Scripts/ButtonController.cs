using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

    [SerializeField] SpriteRenderer img;
	public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void HaloAppear()
    {
        img.enabled = true;
    }
    public void HaloDisappear()
    {
        img.enabled = false;
    }
}
