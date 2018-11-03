using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FishyFollowsPlayer : MonoBehaviour {

    Vector3 initialPosition;
    void Start () {
        initialPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 direccion = Vector3.zero;
        if (Mathf.Abs(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x) > 5f)
        {
            direccion = Vector3.MoveTowards(transform.position, initialPosition, 0.01f);
        }
        else
        {
            direccion = Vector3.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.03f);
        }

        if (direccion.x > transform.position.x && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if (direccion.x < transform.position.x && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        transform.position = new Vector3(direccion.x, direccion.y, 0);
    }
}
