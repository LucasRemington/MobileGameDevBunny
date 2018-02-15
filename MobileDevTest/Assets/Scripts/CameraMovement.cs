using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;
	//public float RotateSpeed = 30f;

	void Start () {
		offset = transform.position - player.transform.position;
	}


	/*void Update () {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Rotate (-Vector3.up * RotateSpeed * Time.deltaTime);
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate (Vector3.up * RotateSpeed * Time.deltaTime);
		}
	}*/

	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
