using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ReplayGame : MonoBehaviour {

	public Button restartBtn;
	private bool paused = false;

	// Use this for initialization
	void Start () {
		restartBtn.onClick.AddListener(Restart);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			paused = !paused;
		}

		if (paused)
		{
			Time.timeScale = 0;
		}
	}


	public void Restart(){
		
		// destruction des positions qui ont été modifier
		Destroy(transform.gameObject);
		// scenemanager LoadScene();
		DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Lampe"));
		SceneManager.LoadScene("ENTIRE HOME");

	}

}
