using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

	public static int score = 0;
	public Text scoreText;


	// Update is called once per frame
	void Update()
	{
		
		scoreText.text = score.ToString();


	}
}