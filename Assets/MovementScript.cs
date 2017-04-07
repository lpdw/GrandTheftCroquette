using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class MovementScript : MonoBehaviour {

	public Transform target;
	public Transform nounou;
	public Transform[] points;
	private int destPoint = 0;
	private NavMeshAgent agent;
	private Animator animator;
	private bool nounouStop = false;
	public bool playerInSight = false;
	private CapsuleCollider col;
	public GameObject cat;
	public GameObject stars;
	public Sprite found;
	public Sprite noFound;
	private bool stopStars;
	private Image[] images;


	// Use this for initialization

	void Start () {

		agent = GetComponent<NavMeshAgent> ();
		animator = GetComponentInChildren<Animator>();
		col = GetComponent<CapsuleCollider> ();
		stopStars = false;
		images = stars.GetComponentsInChildren<Image> ();
		agent.autoBraking = false;
		GotoNextPoint ();

	}
	
	// Update is called once per frame
	void Update () {


		if (agent.speed != 0) {
			animator.SetBool ("Idling", false);
		} else {
			animator.SetBool ("Idling", true);
			animator.SetBool ("NonCombat", true);
		}	


		if (playerInSight) {
			print (agent.remainingDistance);

			int nbStars = 0;
			int distance = (int)agent.remainingDistance;

			if (distance < 15 && distance > 12.5) {
				nbStars = 1;
			} else if (distance > 12.5) {
				nbStars = 2;
			} else if (distance > 10) {
				nbStars = 3;
			} else if (distance > 7.5) {
				nbStars = 4;
			} else if (distance > 5) {
				nbStars = 5;
			} else if (distance < 5) {
				nbStars = 6;
			}
			/*
			for (int i = 0; i<nbStars; i++) {

				images[i].sprite = found;
			}*/

			int compteur = 1;
			foreach (Image image in images) {
				if (compteur <= nbStars && nbStars != 0) {
					image.sprite = found;
				} else {
					image.sprite = noFound;
				}
				compteur++;
			}

			if (agent.remainingDistance > 2f) {
				animator.SetBool ("NonCombat", false);
				agent.speed = 4.5f;
				agent.SetDestination (target.position);
			} else {
				animator.SetBool ("NonCombat", true);
				agent.speed = 0;
				animator.SetBool ("Idling", true);
				agent.SetDestination (agent.transform.position);
			}
		} else {

			if (stopStars) {
				foreach (Image image in images) {
					image.sprite = noFound;
				}
			}

			agent.speed = 3.5f;
			if (agent.remainingDistance < 0.5f && !nounouStop) {
				GotoNextPoint ();
			}

			animator.SetBool ("NonCombat", true);

			if ((nounou.position - points [points.Length - 1].position).magnitude < 4f) {
				nounouStop = true;
				agent.speed = 0;
				StartCoroutine (Stop ());
			}
		}

	}

	void GotoNextPoint() {
		if (points.Length == 0)
			return;
		agent.destination = points[destPoint].position;
		destPoint = (destPoint + 1) % points.Length;
	}


	IEnumerator Stop()
	{
		yield return new WaitForSeconds(5);
		nounouStop = false;
		agent.speed = 3.5f;
	}


	void OnTriggerStay(Collider other)
	{
		if (other.gameObject == cat) {

			/*Vector3 direction = other.transform.position - transform.position;
			float angle = Vector3.Angle (direction, transform.forward);
			RaycastHit hit;

			if(angle < 110f * 0.5f)
			if (Physics.Raycast (transform.position + transform.up, direction.normalized, out hit, col.radius)) {
				if (hit.collider.gameObject == playerInSight) {
					playerInSight = true;
				}
			}*/
			playerInSight = true;
		}

	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject == cat) {
			playerInSight = false;
			stopStars = true;
		}
	}
		
}
