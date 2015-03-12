using UnityEngine;
using System.Collections;

public class SpellRangeCheck : MonoBehaviour {

	public Transform lightningBoltLinecastEnd;
	public Transform powerDrainLinecastEnd;

	private SpellControlScript spellControl;


	void Awake() {
		spellControl = GetComponent<SpellControlScript>();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		lightningBoltRaycast ();
		powerDrainRaycast ();

		spellControl.castSpeedBoost ();
	}

//	void FixedUpdate() {
//		if (Input.GetKeyDown (KeyCode.R)) {
//			rigidbody2D.AddForce(new Vector2(rigidbody2D.velocity.x * 1000, 0));
//		}
//	}


	void lightningBoltRaycast() {

		RaycastHit2D hit = Physics2D.Linecast (transform.position, lightningBoltLinecastEnd.position, 1 << LayerMask.NameToLayer ("Enemy"));
		if (hit.collider != null) {

			// draw line to target
			Debug.DrawLine (transform.position, hit.point, Color.red);

			// call SpellControlScript
			spellControl.castLightningBolt(hit);
			spellControl.castLightningChain(hit);

		}
	}

	void powerDrainRaycast() {

		RaycastHit2D hit = Physics2D.Linecast(transform.position, powerDrainLinecastEnd.position, 1 << LayerMask.NameToLayer ("Enemy"));
		if (hit.collider != null) {

			// draw line to target
			Debug.DrawLine(transform.position, hit.point, Color.cyan);

			// call SpellControlScript
			spellControl.castPowerDrain(hit);

		}
	}
}
