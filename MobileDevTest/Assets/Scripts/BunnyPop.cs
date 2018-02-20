using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyPop : MonoBehaviour {

	public float thrust;
	Rigidbody rigid;
	public bool amDying;
	Animator anim;

	void Start()
	{
		addThrust ();
	}

	void Awake()
	{
		addThrust ();
	}

	void Update()
	{
		if (amDying == true) {
			Rigidbody rigid = GetComponent<Rigidbody>();
			rigid.velocity = Vector3.zero;
			rigid.freezeRotation = true;
		}
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
		anim = GetComponent<Animator>();
		Rigidbody rigid = GetComponent<Rigidbody>();
		rigid.AddForce(Random.insideUnitCircle * thrust);
		amDying = false;
	}
		
	public void Die() {
		anim.SetTrigger("death");
		amDying = true;
	}

	public void End() {
		Destroy(gameObject);
	}

}