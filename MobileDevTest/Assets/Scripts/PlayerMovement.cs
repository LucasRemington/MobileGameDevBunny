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
	public Camera fpsCam;

	void Start () {
		Debug.Log ("start");
		canShoot = true;
	}

	void Update () {

		Touch finger1 = Input.GetTouch (0);
		if (canShoot == true && finger1.phase == TouchPhase.Began) {
			Debug.Log("Bang");
			StartCoroutine(GunCount());
			Ray ray = fpsCam.ScreenPointToRay(finger1.position);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, weaponRange) && hit.transform.tag == "Enemy" && startButton.activeSelf == false) {
				hit.transform.GetComponent<BunnyPop> ().Die ();
				splotSpawn = hit.transform.GetComponent<Transform> ();
				Instantiate (bloodSplot [Random.Range (0, bloodSplot.Length)], splotSpawn.transform.position, splotSpawn.transform.rotation);
				ParentDetach.bloodCount++;
				GameManager.Score++;
				gunShot.Play ();
			} else {
				gunFail.Play ();
			}

		}
	}

	IEnumerator GunCount (){
		canShoot = false;
		yield return new WaitForSecondsRealtime (0.1f);
		canShoot = true;
	}

}
