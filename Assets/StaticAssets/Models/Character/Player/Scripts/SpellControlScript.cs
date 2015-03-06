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
			
			// cast lightningbolt to target
			LightningBoltAnimationScript lb = hit.rigidbody.gameObject.AddComponent<LightningBoltAnimationScript>();
			lb.castLightningBolt(transform, hit.transform);
		}
	}
	
	public void castLightningChain(RaycastHit2D hit) {
		if (Input.GetKeyDown (KeyCode.W)) {
			
			// cast lightningbolt to target
			LightningBoltAnimationScript lb = hit.rigidbody.gameObject.AddComponent<LightningBoltAnimationScript>();
			lb.castLightningBolt(transform, hit.transform);
			
			// spawn chaining script to target
			Vector2 target = hit.point;
			Instantiate( lightningChainDetection, target, Quaternion.identity );
		} 
	}
}
