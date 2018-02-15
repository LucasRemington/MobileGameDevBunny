using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyPop : MonoBehaviour {

	public float thrust;
	Rigidbody rigid;

	void Start()
	{
		addThrust ();
	}

	void Awake()
	{
		addThrust ();
	}

	void OnCollisionEnter(Collision collision)
	{

		if(collision.gameObject.tag == "Wall") {
			Debug.Log ("Hitwall");
			addThrust ();
		}

	}

	void addThrust ()
	{
		Rigidbody rigid = GetComponent<Rigidbody>();
		rigid.AddForce(Random.insideUnitCircle * thrust);
	}
}