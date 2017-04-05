using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	private Rigidbody myRigidBody;
	public  float jumpValue;
	private int move;
	public float moveSpeed = 10f;
	public float turnSpeed = 500f;
	public Animator animChat;	
	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody> ();

	}

	// Update is called once per frame
	void Update () {
		Deplacement ();
		if (Input.GetKeyDown (KeyCode.Space)) {
			animChat.SetTrigger("jump");
				Jump ();
		}
			
	}

	// Fonction pour faire rebondir le joueur
	public void Jump () {
		
		myRigidBody.AddForce (jumpValue * Vector3.up);
	}


	void Deplacement(){
		if (move  == 0) {
			animChat.SetBool ("walk", false);
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			move = 1;
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
			animChat.SetBool ("walk", true);
		}
			

		if (Input.GetKey (KeyCode.DownArrow)) {
			move = 1;
			transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
			animChat.SetBool ("walk", true);
		}
			

		if (Input.GetKey (KeyCode.LeftArrow)) {
			move = 1;
			transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
			animChat.SetBool ("walk", true);
		}
			

		if (Input.GetKey (KeyCode.RightArrow)) {
			move = 1;
			transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);	
			animChat.SetBool ("walk", true);
		}
			
	}
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "Croquette") {
			animChat.SetTrigger ("eat");
		
		}


	} 



}
