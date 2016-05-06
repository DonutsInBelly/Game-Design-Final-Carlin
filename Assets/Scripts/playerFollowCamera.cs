using UnityEngine;
using System.Collections;

public class playerFollowCamera : MonoBehaviour {

	GameObject player;
	playerMovement pm;

	bool followPlayer = true;
	Camera cam;

	public string leftBumper = "LookAhead";

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		pm = player.GetComponent<playerMovement> ();
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton(leftBumper)) {
			followPlayer = false;
			//pm.setMoving (false);
		} else {
			followPlayer = true;
		}

		if (followPlayer == true) {
			camFollowPlayer ();
		} else {
			lookAhead ();
		}
	}

	void setFollowPlayer(bool val) {
		followPlayer = val;
	}

	void camFollowPlayer() {
		Vector3 nextPosition = new Vector3 (player.transform.position.x, player.transform.position.y, this.transform.position.z);
		this.transform.position = nextPosition;
	}

	void lookAhead() {
		//


		Vector3 camPosition = cam.ScreenToWorldPoint (player.transform.rotation * Vector3.up);// new Vector3(player.transform.position.x + 5, player.transform.position.y + 5));
		//camPosition.z = -10;
		Vector3 dir = camPosition;// - this.transform.position;
		if (player.GetComponent<SpriteRenderer> ().isVisible == true) {
			transform.Translate (dir * 2 * Time.deltaTime);
		}
	}
}
