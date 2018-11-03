using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawController : MonoBehaviour {

    Vector3 mousePosition;

	void Update () {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.position = mousePosition; //To move paw!
    }
}
