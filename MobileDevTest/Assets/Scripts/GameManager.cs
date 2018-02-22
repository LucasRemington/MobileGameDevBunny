using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static int Score;
	public Text scoreCount;
	public int scoreLocked;
	public GameObject buttonLose;
	public GameObject bunPrefab;
	public Transform[] spawnPoints;
	public float spawnTime;
	public static int bunsAround;
	public static bool gameStart = false;
	public int publicBuns;
	public AudioSource youLoser;
	public AudioSource pixelDoom;
	public bool stopSpawn;

	void Start () {
		pixelDoom = GetComponent<AudioSource> ();
		BunnyPop.bunnygoBoom = false;
		stopSpawn = false;
	}

	void beginGame () {
		Score = 0;
		bunsAround = 1;
		spawnTime = 2f;
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
		StartCoroutine(speedBuns());
		//youLose.gameObject.SetActive(false);
		buttonLose.gameObject.SetActive(false);
	}
	

	void Update () {
		scoreCount.text = "Score: " + Score.ToString ();
		if (bunsAround > 9) {
			Lose ();
		}
		publicBuns = bunsAround;
		if (gameStart == true) {
			beginGame ();
			gameStart = false;
		}
		if (stopSpawn == true) {
			if (Score != scoreLocked)
			{
				Score = scoreLocked;
			}
		}
	}


	void Spawn ()
	{
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		Instantiate (bunPrefab, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
	}

	IEnumerator speedBuns () {
		if (spawnTime > 1 && stopSpawn == false) {
			yield return new WaitForSecondsRealtime (10f);
			CancelInvoke ();
			spawnTime = spawnTime - 0.25f;
			bunnySpeed ();
			StartCoroutine(speedBuns());
		}
		else if (spawnTime > 0.5 && spawnTime <= 1.0 && stopSpawn == false) {
			yield return new WaitForSecondsRealtime (15f);
			CancelInvoke ();
			spawnTime = spawnTime - 0.1f;
			bunnySpeed ();
			StartCoroutine(speedBuns());
		}
	}

	void bunnySpeed ()
	{
		if (stopSpawn == false) {
			InvokeRepeating ("Spawn", spawnTime, spawnTime);
			Debug.Log ("faster");
		}
	}

	void Lose () {
		CancelInvoke ();
		Debug.Log ("Lose");
		pixelDoom.Stop ();
		youLoser.Play ();
		stopSpawn = true;
		scoreLocked = Score;
		BunnyPop.bunnygoBoom = true;
		buttonLose.gameObject.SetActive(true);
	}
}
