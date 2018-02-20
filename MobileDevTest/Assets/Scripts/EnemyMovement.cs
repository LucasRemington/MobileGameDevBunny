using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public Transform target1;
	public Transform target2;
	public Transform target3;
	public Transform target4;
	public Transform target5;
	public Transform target6;
	Transform target;

	public int pinTarget;
	public float speed;

	public int finalLoopNumber;
	private int loopNumber;
	public bool loopPinPath;

	void Start () {
		pinTarget = 1;
		loopNumber = 0;
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Pin") {
			pinTarget = pinTarget + 1;
			Debug.Log("ChangedPinPath");
		}
		if(other.gameObject.tag == "Goal") {
			Destroy(gameObject);
			//GameManager.Health--;
			Debug.Log("Damage");
		}
	}

	void FixedUpdate () {
		float step = speed * Time.deltaTime;
		if (pinTarget == 1) {
			transform.position = Vector3.MoveTowards (transform.position, target1.position, step);
		} else if (pinTarget == 2) {
			transform.position = Vector3.MoveTowards (transform.position, target2.position, step);
		} else if (pinTarget == 3) {
			transform.position = Vector3.MoveTowards (transform.position, target3.position, step);
		} else if (pinTarget == 4) {
			transform.position = Vector3.MoveTowards (transform.position, target4.position, step);
		} else if (pinTarget == 5) {
			transform.position = Vector3.MoveTowards (transform.position, target5.position, step);
		} else if (pinTarget == 6) {
			transform.position = Vector3.MoveTowards (transform.position, target6.position, step);
		} 
		if (loopPinPath == true && pinTarget > 6) {
			pinTarget = 1;
			if (loopNumber < finalLoopNumber) {
				loopNumber++;
			} else {
				loopPinPath = false;
			}
		}
	}

	public void Die () {
		Destroy(gameObject);
	}
}
