using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

	public static float score = 0;
	public Text scoreText;


	// Update is called once per frame
	void Update()
	{
		print (score);
		scoreText.text = score.ToString("0000000");


	}
}