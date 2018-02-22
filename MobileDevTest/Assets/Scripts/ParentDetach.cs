using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentDetach : MonoBehaviour {

	public Transform trans;
	public static int bloodCount;

	void Awake () {

		trans = GetComponent<Transform>();
		trans = transform.parent;
		transform.parent = null;
		if (bloodCount > 150) {
			Destroy (gameObject);
		} else {
			Destroy (gameObject, 300f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
