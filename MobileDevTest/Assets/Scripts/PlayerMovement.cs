using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	//private Rigidbody rb;
	//public float speed;

	public bool canShoot = true;
	public float weaponRange = 500f;

	public Camera fpsCam;

	void Start () {
		//rb = GetComponent<Rigidbody>();
	}


	void Update () {
		if (Input.GetButtonDown("Fire1") && canShoot == true) {
			Debug.Log("Bang");
			//StartCoroutine(GunCount());
			Ray ray = fpsCam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, weaponRange) && hit.transform.tag == "Enemy") {
				Destroy(hit.transform.gameObject);
				GameManager.Score++;
				GameManager.bunsAround--;
			}
		}
	}

	/*void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}*/

	IEnumerator GunCount (){
		//gunShot.Play ();
		canShoot = false;
		yield return new WaitForSecondsRealtime (0.325f);
		//gunLoad.Play ();
		yield return new WaitForSecondsRealtime (0.325f);
		canShoot = true;
	}

}
