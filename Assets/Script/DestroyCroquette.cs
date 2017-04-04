using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCroquette : MonoBehaviour {

	public Score score;

	void Start(){

	}
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Player")
		{
			score.score =+100;
			print (score.scoreText);
			PlayerPrefs.SetInt("Score", score.score);
			Destroy(gameObject);
		}


	} 

}
