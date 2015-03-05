using UnityEngine;
using System.Collections;

public class CircleRadiusExpander : MonoBehaviour {

	public float maximumRadius = 5; 
	private float deltaRadius = 0.3f;
	private CircleCollider2D circleCollider;

	// Use this for initialization
	void Start () {
		circleCollider = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {

		if (circleCollider.radius >= maximumRadius) {
			Destroy(gameObject);
		} else {
			circleCollider.radius += deltaRadius;
		}
	}
}
