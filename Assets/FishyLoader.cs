using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishyLoader : MonoBehaviour {

    float topLimit = 4f;

    float bottomLimit = -4f;

    float leftLimit = -5f;

    float rightLimit = 5f;

    SimpleObjectPool pool;

    // Use this for initialization
	void Start () {
        int numberOfFishies = PlayerPrefs.GetInt("Fishies");
        //int numberOfFishies = 10;
        pool = GetComponent<SimpleObjectPool>();
        for (int i = 0; i < numberOfFishies; i++)
        {
            GameObject pececito = pool.GetObject();
            float x = Random.Range(leftLimit, rightLimit);
            float y = Random.Range(bottomLimit, topLimit);
            pececito.transform.position = new Vector3(x, y, 0);
            pececito.transform.parent = gameObject.transform;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
