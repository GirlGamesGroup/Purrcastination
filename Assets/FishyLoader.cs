using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishyLoader : MonoBehaviour {

    float topLimit = 1f;

    float bottomLimit = -4f;

    float leftLimit = -3f;

    float rightLimit = 4.5f;

    SimpleObjectPool pool;

    [SerializeField]
    Sprite[] fishieOptions;

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
            pececito.GetComponent<SpriteRenderer>().sprite = fishieOptions[i % 3];
            pececito.transform.position = new Vector3(x, y, 0);
            pececito.transform.parent = gameObject.transform;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
