using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbles : MonoBehaviour {

    AudioSource audioSource;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(MakeBubbles());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator MakeBubbles()
    {
        while(true)
        {
            yield return new WaitForSeconds(8f);
            audioSource.Play();
        }
    }
}
