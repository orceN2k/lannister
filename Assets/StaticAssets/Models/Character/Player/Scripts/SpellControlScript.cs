using UnityEngine;
using System.Collections;

public class SpellControlScript : MonoBehaviour {

	private GameObject lightningChainDetection;

	// Use this for initialization
	void Start () {
		lightningChainDetection = (GameObject)Resources.Load("lightningChainRangeDetection");
	}

	public void castLightningBolt(RaycastHit2D hit){
		if (Input.GetKeyDown (KeyCode.Q)) {

			LightningBoltScript lbScript = gameObject.GetComponentInChildren<LightningBoltScript>();
			lbScript.castLightningBolt(hit.point);

		}
	}
	
	public void castLightningChain(RaycastHit2D hit) {
		if (Input.GetKeyDown (KeyCode.W)) {

			LightningBoltScript lbScript = gameObject.GetComponentInChildren<LightningBoltScript>();
			lbScript.castLightningBolt(hit.point);
			
			// spawn chaining script to target
			Vector2 target = hit.point;
			Instantiate( lightningChainDetection, target, Quaternion.identity );
		} 
	}
}
