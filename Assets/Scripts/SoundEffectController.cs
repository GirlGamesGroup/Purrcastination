using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectController : MonoBehaviour {

    public static SoundEffectController Instance;
    public AudioClip diedSound;
    public AudioClip goOutSound;

    // Use this for initialization
    void Awake() {
        Instance = this;
    }

}
