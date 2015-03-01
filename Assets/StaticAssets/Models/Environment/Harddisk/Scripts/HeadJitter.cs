using UnityEngine;
using System.Collections;

public class HeadJitter : MonoBehaviour {

	public float interval = 0.001f;
	private float lastTime = 0;
	private float totalRotation;
	private float maxRotation = 10f;
	private float minRotation = -5f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (lastTime + interval <= Time.time) {
			lastTime = Time.time;
			leftRotate ();
		}
	}

	void leftRotate () {

		float rotationValue = Random.Range (-5, 5);
		if (totalRotation + rotationValue <= maxRotation & totalRotation + rotationValue > minRotation) {
			transform.Rotate (Vector3.forward * rotationValue);
			totalRotation += rotationValue;
		}
	}

}
