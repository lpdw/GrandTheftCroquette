using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCroquette : MonoBehaviour {

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Player")
		{
			Score.score += 100;
			//PlayerPrefs.SetInt("Score", score.score);
			Destroy(gameObject);
		}


	} 

}
