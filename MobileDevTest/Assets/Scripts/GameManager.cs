using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static int Score;
	//public float min, max;
	public Text scoreCount;
	public GameObject bunPrefab;
	//float radius = 4;
	public Transform[] spawnPoints;
	public float spawnTime;
	public static int bunsAround;
	public bool speedOnce;

	void Start () {
		Score = 0;
		bunsAround = 0;
		spawnTime = 2f;
		speedOnce = false;
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
		StartCoroutine(speedBuns());
	}
	

	void Update () {
		scoreCount.text = "Score: " + Score.ToString ();
		if (bunsAround > 9) {
			Debug.Log ("Lose");
		}
	}


	void Spawn ()
	{
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		Instantiate (bunPrefab, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
		bunsAround++;
	}
	IEnumerator speedBuns () {
		if (speedOnce == false) {
			yield return new WaitForSecondsRealtime (20f);
			CancelInvoke ();
			InvokeRepeating ("Spawn", spawnTime - 1f, spawnTime - 1f);
			speedOnce = true;
			StartCoroutine(speedBuns());
		}

		if (speedOnce == true) {
			yield return new WaitForSecondsRealtime (20f);
			CancelInvoke ();
			InvokeRepeating ("Spawn", spawnTime - 1.5f, spawnTime - 1.5f);
		}
	}

	/*Vector3 GeneratedPosition()
	{
		float x, y, z;
		x = UnityEngine.Random.Range (min, max);
		y = UnityEngine.Random.Range (min, max);
		z = -2.33f;
		return new Vector3 (x, y, z);
	}*/
}
