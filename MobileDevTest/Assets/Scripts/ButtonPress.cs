using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonPress : MonoBehaviour {

	public GameObject startButton;
	public GameObject restartButton;
	public GameObject creditsOverlay;
	public bool startGame = true;
	AudioSource pixelDoom;
	public static bool disableButton;
	public static bool restartYes;
	public Image bloodButton;
	public Sprite[] sprites;

	void Start () {
		bloodButton.GetComponent<Image> ();
		pixelDoom = GetComponent<AudioSource> ();
		disableButton = false;
		if (restartYes == true) {
			OnClick ();
			restartYes = false;
		}
	}

	public void OnClick () {
		//Debug.Log ("click");
		if (startGame == true) {
			startButton.gameObject.SetActive (false);
			restartButton.gameObject.SetActive (false);
			GameManager.gameStart = true;
			//PlayerMovement.canShoot = true;
			startGame = false;
			pixelDoom.Play ();
		} else if (startGame == false && disableButton == false) {
			restartYes = true;
			Reload ();
		}
	}

	public void NoBlood () {
		if (GameManager.wussMode == true) {
			GameManager.wussMode = false; 
			bloodButton.sprite = sprites[0];
			//Debug.Log ("Buttoncolor");
		} else if (GameManager.wussMode == false) {
			GameManager.wussMode = true; 
			bloodButton.sprite = sprites[1];
			//Debug.Log ("Buttoncolor");
		}
	}

	void Update () {
		if (startButton.activeSelf) {
			restartButton.gameObject.SetActive (false);
		}
	}

	public static IEnumerator waittoClick () {
		disableButton = true;
		yield return new WaitForSecondsRealtime (2f);
		disableButton = false;
	}

	public void Credits () {
		if (creditsOverlay.activeSelf == false) {
			creditsOverlay.SetActive (true);
		} else if (creditsOverlay.activeSelf == true) {
			creditsOverlay.SetActive (false);
		}
	}

	public void LucasRemington () {
		Application.OpenURL ("https://lucasremington.github.io");
	}

	public void Reload () {
		if (disableButton == false) {
			GameManager.Score = 0;
			SceneManager.LoadScene ("bunpop");
		}
		//Debug.Log ("restart");
	}
}
