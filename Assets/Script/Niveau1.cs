using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Niveau1 : MonoBehaviour {

	private GameObject porte;
	public Score score;

	// Use this for initialization
	void Start () {
		//score.setMaxScore(6);
		porte = GameObject.FindWithTag ("Porte");
	}

	// Update is called once per frame
	void Update () {

		if (score.score == score.maxScore) {
			print ("Porte débloquée YEAAAH!");
			Debloquer ();
		}

	}

	void Debloquer(){
		Destroy (porte);
	}
}
