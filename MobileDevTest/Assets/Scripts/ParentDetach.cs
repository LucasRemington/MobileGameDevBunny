using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentDetach : MonoBehaviour {

	public Transform trans;
	public static int bloodCount;
	Animator anim;
	private int randomColor;

	void Start () {
	}

	void Awake () {
		trans = GetComponent<Transform>();
		trans = transform.parent;
		transform.parent = null;
		if (bloodCount > 150) {
			Destroy (gameObject);
		} else {
			Destroy (gameObject, 300f);
		}
		if (GameManager.wussMode == true) {
			anim = GetComponent<Animator>();
			randomColor = Random.Range (0, 5);
			if (randomColor == 0) {
				anim.SetTrigger ("red");
			} else if (randomColor == 1) {
				anim.SetTrigger ("yellow");
			} else if (randomColor == 2) {
				anim.SetTrigger ("orange");
			} else if (randomColor == 3) {
				anim.SetTrigger ("green");
			} else if (randomColor == 4) {
				anim.SetTrigger ("blue");
			} else if (randomColor == 5) {
				anim.SetTrigger ("purple");
			}
		}
	}
}
