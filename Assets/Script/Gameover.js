import UnityEngine.UI;
#pragma strict

var Player : GameObject;
var Canvas : GameObject;
var score: int;
var timer : float;
var bonus : float;
private var totalBonus : float;

var scoreText: Text;
var timerText : Text;
var bonusText : Text;

function Start () {
    score =PlayerPrefs.GetInt("Score");
    timer=PlayerPrefs.GetFloat("Timer");
    bonus=PlayerPrefs.GetFloat("Bonus");

    totalBonus = timer - bonus;
}

function Update () {
   
    if(Player==null){
        Player = GameObject.Find("Player");
       
    }
    scoreText.text = score.ToString();
    timerText.text=totalBonus.ToString("f2");
    bonusText.text = bonus.ToString();
}


