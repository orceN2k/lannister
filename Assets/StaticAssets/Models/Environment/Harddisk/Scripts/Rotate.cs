using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rotateLeft ();
	}

	void rotateLeft () {
		transform.Rotate (Vector3.forward * -30);
	}
}
