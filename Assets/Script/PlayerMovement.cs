using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {

	public float speed = 6.0F;//Character Movement Speed.
	public float jumpSpeed = 8.0F;//Character jump Speed.
	public float gravity = 20.0F;//Gravity(We have to apply gravity manualy in character controller component).
	private Vector3 moveDirection = Vector3.zero;//Character Movement Direction.


	void Update () {
		MoveCharacter ();
	}

	//Method For Character Movement
	void MoveCharacter()
	{
		CharacterController controller = GetComponent<CharacterController>();// Get Character Controller Component
		if (controller.isGrounded)//Check Whether The Character is In Air or not
		{
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // Get Input From User
			moveDirection = transform.TransformDirection(moveDirection);//Specify The Character Movement Direction in world space.
			moveDirection *= speed;//Add Movement Speed To Character.
			if (Input.GetButton("Jump"))//Check For JUMP Button.
				moveDirection.y = jumpSpeed;//Make Character JUMP.
		}
		moveDirection.y -= gravity * Time.deltaTime; //Move Character Down Because Of Gravity That We have assign before.
		controller.Move(moveDirection * Time.deltaTime);//Move The Character in specific Direction.
	}

	/*if (Input.GetKeyDown(KeyCode.LeftArrow))
	{

		this.transform.Translate(Vector3(-vitesse, 0, 0));
	}
	else if (Input.GetKeyDown(KeyCode.RightArrow))
	{
		this.transform.Translate(Vector3(vitesse, 0, 0));
	}
	else if (Input.GetKeyDown(KeyCode.UpArrow))
	{
		this.transform.Translate(Vector3(0, 0, vitesse));
	}
	else if (Input.GetKeyDown(KeyCode.DownArrow))
	{
		this.transform.Translate(Vector3(0, 0, -vitesse));
	}*/
}

/*public void Deplacement(){
		
		// Création d'un nouveau vecteur de déplacement
	    move = new Vector3();
	
		if (move.z == 0 || move.z == 0) {
			animChat.SetBool ("walk", false);
		}
	
		// Récupération des touches haut et bas
		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			move.z += 0.1f;
			animChat.SetBool ("walk", true);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			move.z -= 0.1f;
			animChat.SetBool ("walk", true);
		}
		// Récupération des touches gauche et droite

		if(Input.GetKey(KeyCode.LeftArrow)){
			move.x -= 0.1f;
			transform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime);
			animChat.SetBool ("walk", true);
		}	

		if (Input.GetKey (KeyCode.RightArrow)) {
			move.x += 0.1f;
			transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
			animChat.SetBool ("walk", true);
		}
		// On applique le mouvement à l'objet
		transform.position += move;

		// autre solution 
		/*
		if(Input.GetAxis("Horizental")<0)

	}*/