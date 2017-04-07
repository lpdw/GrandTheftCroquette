using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ControlGame : MonoBehaviour {

	public Button playBtn;


	// Use this for initialization
	void Start () {
		
		playBtn.onClick.AddListener(Play);
	}

	// Update is called once per frame
	void Update () {

	}


	public void Play(){
		print("You have clicked the button!");
		SceneManager.LoadScene("ENTIRE HOME");
	}


}
