using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCroquette : MonoBehaviour {
	
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Player")
		{
			Score.score += 100;
			//PlayerPrefs.SetIn t("Score", score.score);
			Destroy(gameObject,1.2f);
		}


	} 

}
