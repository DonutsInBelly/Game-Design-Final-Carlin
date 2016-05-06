using UnityEngine;
using System.Collections;

public class enemyScript : MonoBehaviour 
{
	public float speed;
	public Transform player;
	Spaceship spaceship;

	void FixedUpdate()
	{
		float z = Mathf.Atan2 ((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
		transform.eulerAngles = new Vector3 (0, 0, z);

		GetComponent<Rigidbody2D>().AddForce (gameObject.transform.up * speed);
	}

	// Use this for initialization
	IEnumerator Start () {
		spaceship = GetComponent<Spaceship> ();
		while (true) {
			for (int iter = 0; iter < transform.childCount; iter++) {
				Transform shotPosition = transform.GetChild (iter);
				spaceship.shot (shotPosition);
			}
			yield return new WaitForSeconds (spaceship.shotDelay);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
