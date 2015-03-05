using UnityEngine;
using System.Collections;

// Start or quit the game
public class GameOverScript : MonoBehaviour {

	void OnGUI() {
		const int buttonWidth = 120;
		const int buttonHeight = 60;
		
		if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2),(1 * Screen.height / 3) - (buttonHeight / 2),buttonWidth,buttonHeight),"Retry!")) {

			// Reload the level
			Application.LoadLevel("Scene1");
		}
		
		if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2),(1 * Screen.height / 2) - (buttonHeight / 2),buttonWidth,buttonHeight),"Back to menu")) {

			// Reload the level
			Application.LoadLevel("Menu");
		}
	}
}
