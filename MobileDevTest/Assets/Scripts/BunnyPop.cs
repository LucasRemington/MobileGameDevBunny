﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyPop : MonoBehaviour {

	public float thrust;
	Rigidbody rigid;
	public bool amDying;
	Animator anim;
	AudioSource bunPing;
	public AudioSource bunnyEnter;
	//public AudioSource carrotPop;
	public static bool bunnygoBoom = false;

	void Start()
	{
		notThrust ();
		addThrust ();
	}

	void Awake()
	{
		//GameManager.bunsAround++;
		notThrust ();
		addThrust ();
		bunnyEnter = GetComponent<AudioSource> ();
		//carrotPop = GetComponent<AudioSource> ();
		bunnyEnter.Play ();
	}

	void Update()
	{
		Rigidbody rigid = GetComponent<Rigidbody>();
		if (amDying == true) {
			//Rigidbody rigid = GetComponent<Rigidbody>();
			rigid.velocity = Vector3.zero;
			rigid.freezeRotation = true;
		}
		if (bunnygoBoom == true) {
			Die ();
		}
	}

	void OnCollisionEnter(Collision collision)
	{

		if(collision.gameObject.tag == "Wall") {
			//Debug.Log ("Hitwall");
			addThrust ();
			if (!bunPing.isPlaying){
				bunPing.Play ();
				}
		} else if(collision.gameObject.tag == "Enemy") {
			if (!bunPing.isPlaying){
				bunPing.Play ();
			}
		}

	}

	void addThrust ()
	{
		Rigidbody rigid = GetComponent<Rigidbody>();
		rigid.AddForce(Random.insideUnitCircle * thrust);

	}

	void notThrust ()
	{
		anim = GetComponent<Animator>();
		bunPing = GetComponent<AudioSource> ();
		bunnygoBoom = false;
		amDying = false;
	}

	public void Die() {
		/*if (gameObject.tag == "Carrot") {
			carrotPop.Play ();
			Debug.Log ("carrotplay");
		}*/
		gameObject.tag = "Wall";
		if (GameManager.wussMode == true) {
			anim.SetTrigger ("wussdeath");
		} else { 
			anim.SetTrigger ("death");
		}
		amDying = true;
	}

	public void End() {
		Destroy(gameObject);
	}

}