using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCroquette : MonoBehaviour {

	public Score score;
	private bool detruit = false;

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Player")
		{ 
			//PlayerPrefs.SetIn t("Score", score.score);
			Destroy (gameObject, 1.2f);

			if (!detruit) {
				score.score += 1;
			}

			detruit = true;
		}
			
	} 


}
