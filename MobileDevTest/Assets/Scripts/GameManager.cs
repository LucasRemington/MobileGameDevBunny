using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static int Score;
	//public float min, max;
	public Text scoreCount;
	public Text youLose;
	public GameObject bunPrefab;
	//float radius = 4;
	public Transform[] spawnPoints;
	public float spawnTime;
	public static int bunsAround;
	public int publicBuns;
	//public int speedOnce;

	void Start () {
		Score = 0;
		bunsAround = 1;
		spawnTime = 2f;
		//speedOnce = 0;
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
		StartCoroutine(speedBuns());
	}
	

	void Update () {
		scoreCount.text = "Score: " + Score.ToString ();
		if (bunsAround > 9) {
			Lose ();
		}
		publicBuns = bunsAround;
	}


	void Spawn ()
	{
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		Instantiate (bunPrefab, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
		bunsAround++;
	}

	IEnumerator speedBuns () {
		if (spawnTime > 1) {
			yield return new WaitForSecondsRealtime (10f);
			CancelInvoke ();
			spawnTime = spawnTime - 0.25f;
			bunnySpeed ();
			StartCoroutine(speedBuns());
		}
		else if (spawnTime > 0.5 && spawnTime <= 1.0) {
			yield return new WaitForSecondsRealtime (15f);
			CancelInvoke ();
			spawnTime = spawnTime - 0.1f;
			bunnySpeed ();
			StartCoroutine(speedBuns());
		}
	}

	void bunnySpeed ()
	{
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
		Debug.Log ("faster");
	}

	void Lose () {
		CancelInvoke ();
		Debug.Log ("Lose");
		PlayerMovement.canShoot = false;
		youLose.gameObject.SetActive(true);
	}
		
	/*Vector3 GeneratedPosition(){
		float x, y, z;
		x = UnityEngine.Random.Range (min, max);
		y = UnityEngine.Random.Range (min, max);
		z = -2.33f;
		return new Vector3 (x, y, z);
	}*/

	//consolidate into one function - track individiual bun kills
}
