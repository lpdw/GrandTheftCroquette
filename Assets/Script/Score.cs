using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

	public int score = 0;
	public int maxScore = 0;
	public Text scoreText;
	public Text maxScoreText;


	// Update is called once per frame
	void Update()
	{
		scoreText.text = score.ToString() + "";
		maxScoreText.text = "/" + maxScore;
	}

	public void setMaxScore(int maxScoreValue)
	{
		maxScore = maxScoreValue;
	}
}	