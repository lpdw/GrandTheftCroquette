using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementScript : MonoBehaviour {

	public Transform target;
	public Transform nounou;
	public Transform[] points;
	private int destPoint = 0;
	private NavMeshAgent agent;
	private Animator animator;
	private bool nounouStop = false;
	public bool playerInSight;
	private CapsuleCollider col;
	public GameObject cat;


	// Use this for initialization

	void Start () {

		agent = GetComponent<NavMeshAgent> ();
		animator = GetComponentInChildren<Animator>();
		col = GetComponent<CapsuleCollider> ();
		agent.autoBraking = false;
		GotoNextPoint ();

	}
	
	// Update is called once per frame
	void Update () {

		if (playerInSight) {
			animator.SetBool ("NonCombat", false);
			agent.speed = 7f;
			agent.SetDestination (target.position);
			/*if (agent.remainingDistance < 2f) {
				animator.SetBool ("NonCombat", true);
				animator.SetBool ("Idling", true);
				agent.speed = 0;
			}*/
		} else {

			if (agent.remainingDistance < 0.5f && !nounouStop) {
				GotoNextPoint ();
			}

			animator.SetBool ("NonCombat", true);

			if (agent.speed != 0) {
				animator.SetBool ("Idling", false);
			} else {
				animator.SetBool ("Idling", true);
			}	

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
			playerInSight = true;
		}

	}
		
}
