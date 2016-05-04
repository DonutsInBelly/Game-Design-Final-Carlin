using UnityEngine;
using System.Collections;

public class playerShootOnAxis : MonoBehaviour 
{
	public GameObject bullet;
	public float speed = 5;

	public Quaternion currentDirection;

	public string horizontalAxisRight = "RightHorizontal";
	public string verticalAxisRight = "RightVertical";
	public string horizontal = "Horizontal";
	public string vertical = "Vertical";

	public string fireButton = "Fire1";
	public float fireRate = 0.5f;
	public float nextShot = 0.0f;

	IEnumerator Start ()
	{
		while (true) {
			Instantiate (bullet, transform.position, transform.rotation);
			yield return new WaitForSeconds (0.05f);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Vector3 shootDirection = Vector3.right * Input.GetAxis (horizontalAxisRight) + Vector3.up * Input.GetAxis (verticalAxisRight);
		//transform.rotation = Quaternion.LookRotation (shootDirection, Vector3.forward);
		Vector3 lookDirection = new Vector3(Input.GetAxis(horizontalAxisRight), Input.GetAxis(verticalAxisRight), 0.0f);
		if(lookDirection.sqrMagnitude<0.2f)
			{
				return;
			}
		var angle = Mathf.Atan2(Input.GetAxis(horizontalAxisRight), Input.GetAxis(verticalAxisRight))*Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, 0, angle);
		currentDirection = Quaternion.Euler (0, 0, angle);

		/*float x = Input.GetAxisRaw (horizontal);
		float y = Input.GetAxisRaw (vertical);

		Vector2 direction = new Vector2 (x, y).normalized;
		GetComponent<Rigidbody2D> ().velocity = direction * speed;*/
		if (Input.GetButton (fireButton) && Time.time > nextShot) {
			nextShot = Time.time + fireRate;
		}
	}
}
