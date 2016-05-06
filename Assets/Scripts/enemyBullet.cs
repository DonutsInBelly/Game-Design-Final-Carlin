using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class enemyBullet : MonoBehaviour {

	public int speed = 10;
	public Rigidbody2D rigid;

	public GameObject explosion;

	// Use this for initialization
	void Start () {
		rigid = this.GetComponent<Rigidbody2D> ();
		rigid.velocity = transform.up.normalized * speed;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			Instantiate (explosion, other.transform.position, Quaternion.identity);
			Destroy (other.gameObject);

			SceneManager.LoadScene ("test");
		}
		if (other.gameObject.tag != "Enemy") {
			Instantiate (explosion, this.transform.position, Quaternion.identity);
			Destroy (this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
