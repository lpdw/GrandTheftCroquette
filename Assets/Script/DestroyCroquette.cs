using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCroquette : MonoBehaviour {

	public Score score;

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Player")
		{
			score.score  += 1;
			//PlayerPrefs.SetIn t("Score", score.score);
			Destroy(gameObject,1.2f);
		}


	} 

}
