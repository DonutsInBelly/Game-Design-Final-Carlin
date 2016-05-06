using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("die", 1f);
	}

	void die() {
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
