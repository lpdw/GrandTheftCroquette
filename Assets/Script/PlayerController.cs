using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	private Rigidbody myRigidBody;
	public  float jumpValue;
	public Vector3 move;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody> ();

	}

	// Update is called once per frame
	void Update () {
		Deplacement ();
		if (Input.GetKeyDown (KeyCode.Space)) {
			Jump ();
		}

	}

	// Fonction pour faire rebondir le joueur
	public void Jump () {
		myRigidBody.AddForce (jumpValue * Vector3.up);
	}


	public void Deplacement(){
		
		// Création d'un nouveau vecteur de déplacement
	    move = new Vector3();
	
		// Récupération des touches haut et bas
		if(Input.GetKey(KeyCode.UpArrow))
			move.z += 0.1f;
		if(Input.GetKey(KeyCode.DownArrow))
			move.z -= 0.1f;

		// Récupération des touches gauche et droite
		if(Input.GetKey(KeyCode.LeftArrow))
			move.x -= 0.1f;
		if(Input.GetKey(KeyCode.RightArrow))
			move.x += 0.1f;

		// On applique le mouvement à l'objet
		transform.position += move;

		// autre solution 
		/*
		if(Input.GetAxis("Horizental")<0)
		*/
	}



}
