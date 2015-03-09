using UnityEngine;
using System.Collections;

public class SpellControlScript : MonoBehaviour {

	public float lightningBoltDmg = 40;

	private GameObject lightningChainDetection;

	// Use this for initialization
	void Start () {
		lightningChainDetection = (GameObject)Resources.Load("lightningChainRangeDetection");
	}

	public void castLightningBolt(RaycastHit2D hit){
		if (Input.GetKeyDown (KeyCode.Q)) {

			LightningBoltScript lbScript = gameObject.GetComponentInChildren<LightningBoltScript>();
			lbScript.castLightningBolt(hit.transform);

		}
	}
	
	public void castLightningChain(RaycastHit2D hit) {
		if (Input.GetKeyDown (KeyCode.W)) {

			LightningBoltScript lbScript = gameObject.GetComponentInChildren<LightningBoltScript>();
			lbScript.castLightningBolt(hit.transform);
			
			// spawn chaining script to target
			Vector2 target = hit.point;

			// ignore first target for additional lightningchain (would chain itselfs)
			hit.rigidbody.gameObject.AddComponent<Hit>();
			Instantiate( lightningChainDetection, target, Quaternion.identity );
		} 
	}

	public void castPowerDrain(RaycastHit2D hit) {
		if (Input.GetKeyDown (KeyCode.E)) {

			PowerDrainScript pdScript = gameObject.GetComponentInChildren<PowerDrainScript>();
			pdScript.castPowerDrain(hit.transform);
		}
	}
}
