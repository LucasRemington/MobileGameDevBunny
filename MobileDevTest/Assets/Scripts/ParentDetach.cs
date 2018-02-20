using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentDetach : MonoBehaviour {

	public Transform trans;

	void Awake () {

		trans = GetComponent<Transform>();
		trans = transform.parent;
		transform.parent = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
