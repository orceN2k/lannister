using UnityEngine;
using System.Collections;

public class SpellRangeCheck : MonoBehaviour {

	public Transform lightningBoltLinecastEnd;
	public bool lightningBoltEnable = false;
	public bool lightningChainEnable = false;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Raycast ();
	}

	void Raycast() {

		RaycastHit2D hit = Physics2D.Linecast (transform.position, lightningBoltLinecastEnd.position, 1 << LayerMask.NameToLayer ("Enemy"));
		if (hit.collider != null) {

			// draw line to target
			Debug.DrawLine (transform.position, hit.point, Color.red);

			// call SpellControlScript
			SpellControlScript scScript = gameObject.GetComponent<SpellControlScript>();
			scScript.castLightningBolt(hit);
			scScript.castLightningChain(hit);

		}
	}
}
