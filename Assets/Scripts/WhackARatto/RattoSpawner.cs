using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RattoSpawner : MonoBehaviour {
	
	[SerializeField] protected GameObject Ratto;
	private Vector3[] SpawnPoints;
	private bool[] hasRatto;
	[SerializeField] protected int PeriodOf = 1;
	private int TotalRattos;

	private bool SpawnedRatto;

	// Use this for initialization
	void Start () {
		SpawnedRatto = false;

		SpawnPoints = new Vector3[3];
		hasRatto = new bool[3];
		TotalRattos = 0;

		SpawnPoints [0] = new Vector3 (-2.75f, 0.39f, -0.61f);
		SpawnPoints [1] = new Vector3 (0.42f, -1.83f, -0.61f);
		SpawnPoints [2] = new Vector3 (3.44f, 0.39f, -0.61f);

		for (int i = 0; i < 3; i++) {
			hasRatto [i] = false;
		}
	}

	private void OnEnable () {
		InvokeRepeating ("SpawnRat", 1, PeriodOf);
	}

	private void SpawnRat() {
		SpawnedRatto = false;
		int randomHole;
		while (!SpawnedRatto && TotalRattos < 3) {
			randomHole = Random.Range (0, 3);
			if (!hasRatto [randomHole]) {
				Instantiate (Ratto, SpawnPoints [randomHole], Quaternion.identity);
				hasRatto [randomHole] = true;
				SpawnedRatto = true;
				TotalRattos++;

			} else {
				SpawnedRatto = false;
			}
		}
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void killRatto(int i){
		hasRatto [i] = false;
		TotalRattos--;
	}

}
