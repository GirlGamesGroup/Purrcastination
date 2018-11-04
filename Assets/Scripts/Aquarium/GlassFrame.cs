using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassFrame : MonoBehaviour {

    AudioSource audioSource;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        audioSource.Play();
    }
}
