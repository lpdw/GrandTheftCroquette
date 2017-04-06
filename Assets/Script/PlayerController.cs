using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	private Rigidbody myRigidBody;
	public  float jumpValue = 300f;
	public float moveSpeed = 8f;
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

		if (Input.GetKeyUp (KeyCode.UpArrow) || Input.GetKeyUp (KeyCode.DownArrow)) {
			animChat.SetBool ("walk", false);	
		}

		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
			animChat.SetBool ("walk", true);
		}
			

		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
			animChat.SetBool ("walk", true);
		}
			

		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
		}
			

		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);	
		}
			
	}
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "Croquette") {
			print ("eat");
			animChat.SetTrigger ("eat");
		
		}


	} 



}
