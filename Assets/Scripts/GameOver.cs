using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	private GameObject guiT;
	private GameObject ball;

	void OnTriggerEnter(Collider col) {
		if(col.gameObject.name == "Ball") {
			StartCoroutine(GameIsOver());
		}
	}
	
	IEnumerator GameIsOver() {
		ball = GameObject.Find ("Ball");
		Destroy (ball);
		audio.Play();
		guiT = GameObject.Find ("GameStatus");
		guiT.guiText.text = "Game over! Restarting...";
		yield return new WaitForSeconds(2);
		Application.LoadLevel (Application.loadedLevelName);
	}
}