using UnityEngine;
using System.Collections;

public class SpellRangeCheck : MonoBehaviour {

	public Transform lightningBoltLinecastEnd;
	public Transform powerDrainLinecastEnd;
	public float powerDrainRadius = 10f;
	
	public bool lightningBoltEnable = false;
	public bool lightningChainEnable = false;

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
	}

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
