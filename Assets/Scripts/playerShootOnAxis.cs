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

	public Vector3 mousePos;
	public Camera cam;
	public Rigidbody2D rigid;

	//IEnumerator Start ()
	void Start()
	{
		cam = Camera.main;
		rigid = this.GetComponent<Rigidbody2D> ();

		/*while (true) {
			Instantiate (bullet, transform.position, transform.rotation);
			yield return new WaitForSeconds (0.05f);
		}*/
		return;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		turnToMouse ();

		Vector3 lookDirection = new Vector3(Input.GetAxis(horizontalAxisRight), Input.GetAxis(verticalAxisRight), 0.0f);
		if(lookDirection.sqrMagnitude<0.2f)
			{
				return;
			}
		var angle = Mathf.Atan2(Input.GetAxis(horizontalAxisRight), Input.GetAxis(verticalAxisRight))*Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, 0, angle);
		currentDirection = Quaternion.Euler (0, 0, angle);

		float input = Input.GetAxis ("Vertical");
		rigid.AddForce (gameObject.transform.up * speed * input);
		/*float x = Input.GetAxisRaw (horizontal);
		float y = Input.GetAxisRaw (vertical);

		Vector2 direction = new Vector2 (x, y).normalized;
		GetComponent<Rigidbody2D> ().velocity = direction * speed;*/
	}

	void Update()
	{
		if ((Input.GetButton (fireButton) || Input.GetAxis (fireButton)==1) && Time.time > nextShot) {
			Instantiate (bullet, transform.position, transform.rotation);
			nextShot = Time.time + fireRate;
		}
	}

	void turnToMouse()
	{
		/*mousePos = cam.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - cam.transform.position.z));
		rigid.transform.eulerAngles = new Vector3 (0, 0, Mathf.Atan2 ((mousePos.y - transform.position.y), (mousePos.x - transform.position.x)) * Mathf.Rad2Deg);*/
		//Vector3 shootDirection = Vector3.right * Input.GetAxis (horizontalAxisRight) + Vector3.up * Input.GetAxis (verticalAxisRight);
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.rotation = Quaternion.LookRotation (transform.position - mousePos, Vector3.forward);
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		//rigid.angularVelocity = new Vector3 (0, 0, transform.eulerAngles.z);
		rigid.angularVelocity = 0;

	}
}