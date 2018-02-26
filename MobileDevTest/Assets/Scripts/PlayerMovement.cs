using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public GameObject startButton;
	public AudioSource gunShot;
	public AudioSource gunFail;
	public bool canShoot;
	public bool itsOver;
	public float weaponRange = 500f;
	Transform splotSpawn;
	public GameObject[] bloodSplot;
	public GameObject wussSpot;
	public Camera fpsCam;

	void Start () {
		Debug.Log ("start");
		canShoot = true;
	}

	void LateUpdate () {

		Touch finger1 = Input.GetTouch (0);
		if (canShoot == true && finger1.phase == TouchPhase.Began) { 
		//if (Input.GetButtonDown("Fire1") && canShoot == true) {
			Debug.Log("Bang");
			StartCoroutine(GunCount());
			Ray ray = fpsCam.ScreenPointToRay(finger1.position);
			//Ray ray = fpsCam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, weaponRange) && hit.transform.tag == "Enemy" && startButton.activeSelf == false) {
				hit.transform.GetComponent<BunnyPop> ().Die ();
				splotSpawn = hit.transform.GetComponent<Transform> ();
				ParentDetach.bloodCount++;
				GameManager.Score++;
				gunShot.Play ();
				if (GameManager.wussMode == true) {
					Instantiate (wussSpot, splotSpawn.transform.position, splotSpawn.transform.rotation);
					//bang ();
				} else {
					Instantiate (bloodSplot [Random.Range (0, bloodSplot.Length)], splotSpawn.transform.position, splotSpawn.transform.rotation);
					//bang ();
				}
			} else {
				gunFail.Play ();
			}

		}
	}

	/*void bang () {
		ParentDetach.bloodCount++;
		GameManager.Score++;
		gunShot.Play ();
	}*/

	IEnumerator GunCount (){
		canShoot = false;
		yield return new WaitForSecondsRealtime (0.1f);
		canShoot = true;
	}

}
