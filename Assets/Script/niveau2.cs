using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Niveau2 : MonoBehaviour {

	//private GameObject porte;
	public Score score;

	// Use this for initialization
	void Start () {
		score.setMaxScore(8);
		//porte = GameObject.FindWithTag ("Porte");
	}

	// Update is called once per frame
	void Update () {

		if (score.score == score.maxScore) {
      print("Bravo tu as fini le jeu sans mourir :-)");
		}

	}

	/*void Debloquer(){
		Destroy (porte);
	}*/
}
