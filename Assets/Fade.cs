using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

	private CanvasGroup can;

	// Use this for initialization
	void Start () {
		can = GetComponent<CanvasGroup> ();
		can.alpha = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void FadeIn(){
		StartCoroutine (FadeInCoroutine ());
	}

	IEnumerator FadeInCoroutine()
	{
		for (int i = 0; i < 200; i++) {
			can.alpha += 0.005f;
			yield return null;
		}

	}
}
