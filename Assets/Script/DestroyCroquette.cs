using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCroquette : MonoBehaviour {

	private int score = 0;

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "Croquette")
		{
			score =+1;
			print (score);
			Destroy(col.gameObject);
		}


	} 

}
