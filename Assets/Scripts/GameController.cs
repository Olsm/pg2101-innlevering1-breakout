using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private int lives;
	private int score;
	private int numBricks;

	public float speed;
	public GameObject BrickParticle;

	private GameObject cloneBrickParticle;
	private GameObject player;
	private GameObject bottomWall;
	private GameObject guiT;
	private GameObject destroyBrickSound;

	// Use this for initialization

		
	IEnumerator Start () {
		score = 0;
		lives = 3;
		numBricks = 40;
		player = GameObject.Find("Player");
		bottomWall = GameObject.Find ("BottomWall");
		destroyBrickSound = GameObject.Find("Bricks");
		yield return new WaitForSeconds(1);
		transform.eulerAngles = new Vector3 (0, Random.Range (-60,60), 0);
		rigidbody.velocity = new Vector3 (speed,0,speed);
		audio.Play(); // start music
		StartCoroutine(PauseCoroutine());
	}

	// Update is called once per frames
	void Update () {


	}

	void FixedUpdate () {

	}
	
	void OnCollisionEnter(Collision col) {
		if(col.gameObject.name.Contains ("Brick")) {

			// Destroy previous brick particle
			cloneBrickParticle = GameObject.Find ("BrickParticle(Clone)");
			if (cloneBrickParticle != null) {
				Destroy (cloneBrickParticle);
			}

			// Start explosion sound, instantiate brick particle, and destroy brick
			destroyBrickSound.audio.Play ();
			Instantiate (BrickParticle, col.transform.position, Quaternion.identity);
			Destroy(col.gameObject);
			numBricks--;	// reduce number of bricks by one

			// add score according to brick color
			if (col.gameObject.name == "BlueBrick") 
				score+= 1;
			else if (col.gameObject.name == "CyanBrick")
				score+= 2;
			else if (col.gameObject.name == "GreenBrick")
				score += 3;
			else if (col.gameObject.name == "YellowBrick")
				score += 4;
			else if (col.gameObject.name == "OrangeBrick")
				score += 5;
			else if (col.gameObject.name == "BrownBrick")
				score += 6;
			else if (col.gameObject.name == "PurpleBrick")
				score += 7;
			else if (col.gameObject.name == "RedBrick")
				score += 8;
			// write new gamescore
			guiT = GameObject.Find ("GameScore");
			guiT.guiText.text = "Score: " + score;

			// If there are no bricks left player has won
			if (numBricks == 0) {
				GameWon();
			}
		}
		if (col.gameObject.name == "TopWall") {
			player.transform.localScale = new Vector3 (6f, 1.2f, 1f);
		}
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.name == "BottomWall") {
			StartCoroutine (GameOver ());
		}
	}

	IEnumerator GameOver() {
		guiT = GameObject.Find ("GameStatus");
		if (lives > 0) {
			guiT.guiText.text = "One life lost! " + (lives - 1) + " left...";
		} 
		else if (lives == 0) {
			guiT.guiText.text = "Game over! Restarting...";
		}

		audio.Stop ();
		bottomWall.audio.Play();
		yield return new WaitForSeconds(2);
		guiT.guiText.text = "";

		if (lives == 0) 
			Application.LoadLevel ("Menu");
		else {
			lives--;
			transform.position = new Vector3(0, 0, 2);;
			transform.eulerAngles = new Vector3 (0, Random.Range (-60, 60), 0);
			rigidbody.velocity = transform.forward * speed;
			audio.Play(); // start music
		}
	}

	void GameWon() {
		player.audio.PlayDelayed (0.5f); // pause 0.5 seconds before playing audio
		guiT = GameObject.Find ("GameStatus");
		guiT.guiText.text = "You Won!";
		Destroy (gameObject);
		Application.LoadLevel("Menu");
	}

	IEnumerator PauseCoroutine() {
	
		while (true) {
			if(Input.GetKeyDown(KeyCode.P)) {
				audio.Pause();

			if(Time.timeScale == 0){
					Time.timeScale = 1;
						audio.Play();

				}else {
					Time.timeScale = 0;
				}	
			}
			yield return null;
		}
	}
}

