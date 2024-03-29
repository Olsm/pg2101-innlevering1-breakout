﻿using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	void OnGUI () {

		const int buttonWidth = 120;
		const int buttonHeight = 60;
		
		// Determine the button's place on screen
		Rect buttonRect = new Rect(Screen.width / 2 - (buttonWidth / 2),(2 * Screen.height / 3) - (buttonHeight / 2),buttonWidth,buttonHeight);
		
		// Draw a button to start the game
		if(GUI.Button(buttonRect,"Start!")) {

			// On Click, load the first level.
			Application.LoadLevel("Scene1");
			audio.Play();
		}
	}
}
