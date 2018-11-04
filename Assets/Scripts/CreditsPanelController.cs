using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsPanelController : MonoBehaviour {

    private Vector3 movePosition;
	void Update () {

        if (transform.position.y <= 1590)
        {
            movePosition = transform.position;
            movePosition.y += 0.5f;
            transform.position = movePosition;
        }
	}
}
