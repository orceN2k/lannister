using UnityEngine;
using System.Collections;

public class SpeedBoostScript : MonoBehaviour {

	public float boostForce = 1000f;

	private Rigidbody2D body;
	private AudioSource boostAudio;

	void Awake() {
		body = GetComponentInParent<Rigidbody2D>();
		boostAudio = GetComponent<AudioSource>();
	}

	public void castSpeedBoost() {

		boostAudio.Play ();
		body.AddForce(new Vector2(body.velocity.x * boostForce, 0));
	}
}
