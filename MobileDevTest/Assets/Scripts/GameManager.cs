using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static int Score;
	public Text scoreCount;
	public Text bunCount;
	public int scoreLocked;
	public GameObject buttonLose;
	public GameObject bunPrefab;
	public GameObject carrotPrefab;
	public Transform[] spawnPoints;
	public float spawnTime;
	public int bunsAround;
	public static bool gameStart = false;
	public int publicBuns;
	public AudioSource youLoser;
	public AudioSource pixelDoom;
	public bool stopSpawn;
	public static bool wussMode = false;
	private bool loseOnce;

	void Start () {
		Score = 0;
		ParentDetach.bloodCount = 0;
		loseOnce = false;
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
		StartCoroutine (carrotSpawn ());
		buttonLose.gameObject.SetActive(false);
	}


	void Update () {
		scoreCount.text = "Score: " + Score.ToString ();
		bunCount.text = "Bunnies: " + bunsAround.ToString ();
		if (bunsAround > 9 && loseOnce == false) {
			Lose ();
		}
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		bunsAround = enemies.Length;
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
		if (!youLoser.isPlaying && BunnyPop.bunnygoBoom == true && stopSpawn == false){
			youLoser = GetComponent<AudioSource> ();
			youLoser.Play ();
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

	IEnumerator carrotSpawn () {
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		yield return new WaitForSecondsRealtime (15f);
		if (bunsAround > 7 && stopSpawn == false || Score > 80 && stopSpawn == false) {
			Instantiate (carrotPrefab, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
		}
		//Debug.Log ("carrotspawn");
		StartCoroutine (carrotSpawn ());
	}

	void bunnySpeed ()
	{
		if (stopSpawn == false) {
			InvokeRepeating ("Spawn", spawnTime, spawnTime);
			//Debug.Log ("faster");
		}
	}

	void Lose () {
		loseOnce = true;
		CancelInvoke ();
		//Debug.Log ("Lose");
		pixelDoom.Stop ();
		if (!youLoser.isPlaying){
			youLoser.Play ();
		}
		stopSpawn = true;
		scoreLocked = Score;
		BunnyPop.bunnygoBoom = true;
		buttonLose.gameObject.SetActive(true);
		StartCoroutine(ButtonPress.waittoClick());
	}

	public static IEnumerator bunnyGoBoom () {
		BunnyPop.bunnygoBoom = true;
		yield return new WaitForSecondsRealtime(0.2f);
		BunnyPop.bunnygoBoom = false;
	}
}
