using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPress : MonoBehaviour {

	public GameObject startButton;
	public GameObject restartButton;
	public bool startGame = true;
	AudioSource pixelDoom;

	void Start () {
		pixelDoom = GetComponent<AudioSource> ();
	}

	public void OnClick () {
		Debug.Log ("click");
		if (startGame == true) {
			startButton.gameObject.SetActive (false);
			restartButton.gameObject.SetActive (false);
			GameManager.gameStart = true;
			//PlayerMovement.canShoot = true;
			startGame = false;
			pixelDoom.Play ();
		} else if (startGame == false) {
			GameManager.Score = 0;
			SceneManager.LoadScene ("bunpop");
			Debug.Log ("restart");
		}
	}

	void Update () {
		if (startButton.activeSelf) {
			restartButton.gameObject.SetActive (false);
		}
	}
}
