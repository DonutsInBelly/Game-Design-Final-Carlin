using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour 
{
	public float speed = 1.0f;
	public string verticalAxis = "RightVertical";
	public string horizontalAxis = "RightHorizontal";

	void FixedUpdate () {
		//var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		//Quaternion rot = Quaternion.LookRotation (transform.position - mousePosition, Vector3.forward);
		//transform.rotation = rot;

	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position += speed*(Vector3.right*Input.GetAxis (horizontalAxis) + Vector3.up*Input.GetAxis (verticalAxis)).normalized*Time.deltaTime;
	}
}
