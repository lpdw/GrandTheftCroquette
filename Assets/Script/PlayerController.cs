using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	private Rigidbody myRigidBody;
	public  float jumpValue;
	public float moveSpeed = 8f;
	public float turnSpeed = 200f;
	public Animator animChat;
	public Fade fade;
	private bool isJumping = false;
	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody> ();

	}

	// Update is called once per frame
	void Update () {
		Deplacement ();
		if (Input.GetKeyDown (KeyCode.Space) && isJumping==false) {
				Jump ();
		}
			
	}

	// Fonction pour faire rebondir le joueur
	public void Jump () {
		myRigidBody.AddForce (jumpValue * Vector3.up);
	}

	void FixedUpdate(){
		
		RaycastHit hit;
		if (Physics.Raycast (transform.position, -Vector3.up, out hit)) {
			//print (hit.distance);
			// Si la distance est inférieur à 2, on peut sauter
			if (hit.distance > 1.5f)
				isJumping = true;
			else
				isJumping = false;
		}
		
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
			animChat.SetTrigger ("eat");
		
		}

		if (col.gameObject.tag == "Nounou") {
			print ("wasted");
			fade.FadeIn ();
			 moveSpeed = 0f;
			 turnSpeed = 0f;
			//transform.Rotate(Vector3.up, 300.0f * Time.deltaTime);
		}

	}



}
