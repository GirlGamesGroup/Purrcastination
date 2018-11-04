using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RattoMovementScript : MonoBehaviour {

    private AudioSource audioSource;


    private int currentPlace;
	private bool[] hasRattoTemp;
	private RattoSpawner RS;
	private bool hasBeenCreated;
	private SpriteRenderer SpRen;

	private Vector3 EndPos;
	private Vector3 StartPos;
	private Vector3 MiddlePos;
	[SerializeField] protected float speedRatto;
	private float step;

	private bool isAlreadyDying;


	void Awake(){
		step = speedRatto * Time.deltaTime;
        audioSource = GetComponent<AudioSource>();

    }

	void Start () {
		isAlreadyDying = false;

		SpRen = GetComponent<SpriteRenderer> ();
		RS =GameObject.FindGameObjectWithTag("RattoSpawner").GetComponent<RattoSpawner> ();

		if (gameObject.transform.position == new Vector3(-3.82f, -1.81f, -0.61f)) {
			currentPlace = 0;
		} else if (gameObject.transform.position == new Vector3(0.37f, -0.88f, -0.61f)) {
			currentPlace = 1;
		} else {
			currentPlace = 2;
		}

		StartPos = gameObject.transform.position;
		EndPos = gameObject.transform.position;
		EndPos.y += 1.5f;

		StartCoroutine (LifeCycle());
	}
	
	IEnumerator LifeCycle(){

        audioSource.clip = SoundEffectController.Instance.goOutSound;
        audioSource.Play();
        yield return new WaitForSeconds(0.3f);
        
        while (transform.position != EndPos) {
			transform.position = Vector3.MoveTowards (transform.position, EndPos, step);
			yield return new WaitForEndOfFrame ();
		}

		//yield return new WaitForSeconds(0.1f);
		//SpRen.flipX = true;
		//yield return new WaitForSeconds(0.1f);
		//SpRen.flipX = false;	
		//yield return new WaitForSeconds(0.1f);
		//SpRen.flipX = true;
		//yield return new WaitForSeconds(0.1f);
		//SpRen.flipX = true;
		while (transform.position != StartPos) {
			transform.position = Vector3.MoveTowards (transform.position, StartPos, step);
			yield return new WaitForEndOfFrame ();
		}

		RS.killRatto (currentPlace);
		Debug.Log ("Died on his own");
		Destroy(gameObject);
	}

	private void Die(){
		RS.killRatto (currentPlace);
		Debug.Log ("Killed by player");
		Destroy(gameObject);
	}

	void OnMouseDown ()
	{
		if (!isAlreadyDying) {
			StopAllCoroutines ();
			StartCoroutine (HitCoroutine());
		}

	}

	IEnumerator HitCoroutine(){
		if (!isAlreadyDying) {
			isAlreadyDying = true;
			StartCoroutine (ShakeAnimation ());
		}
		yield return 0;
	}

	IEnumerator ShakeAnimation(){

        audioSource.clip = SoundEffectController.Instance.diedSound;
        audioSource.Play();
		MiddlePos = gameObject.transform.position;
		Vector3 LeftPos = gameObject.transform.position;
		LeftPos.x += 0.2f;
		Vector3 RightPos =  gameObject.transform.position;
		RightPos.x -= 0.2f;

		int nTimes = 0;
		while (nTimes < 2) {
			transform.position = LeftPos;
			yield return new WaitForSeconds (0.05f);
			transform.position = RightPos;
			nTimes++;
			yield return new WaitForSeconds (0.05f);
		}

		transform.position = MiddlePos;
		StartCoroutine (GoDownAfterDying());
		}

	IEnumerator GoDownAfterDying(){
					while (transform.position != StartPos) {
						transform.position = Vector3.MoveTowards (transform.position, StartPos, step*3f);
						yield return new WaitForEndOfFrame ();
		
					}
					Die();
	}

	void Update(){

		

//		}
		
	}

}
