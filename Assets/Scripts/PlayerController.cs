using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 1f;

	private Vector3 playerPos = new Vector3 (0, 0, 0);

	// Use this for initialization
	void Start () {		
	}
	
	// Update is called once per frame
	void Update () {
		float xPos = transform.position.x + (Input.GetAxis("Horizontal") * speed);
		playerPos = new Vector3 (Mathf.Clamp (xPos, -26f, 26f), 0, 0);
		transform.position = playerPos;

}

}