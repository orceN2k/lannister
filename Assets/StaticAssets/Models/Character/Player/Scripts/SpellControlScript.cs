using UnityEngine;
using System.Collections;

public class SpellControlScript : MonoBehaviour {

	public float lightningBoltEnergy = 10f;
	public float lightningChainEnergy = 5f;
	public float speedBoostEnergy = 5f;
	public float powerDrainEnergy = 0f;

	private GameObject lightningChainDetection;
	private Player player;

	// Use this for initialization
	void Start () {
		lightningChainDetection = (GameObject)Resources.Load("lightningChainRangeDetection");
		player = gameObject.GetComponent<Player>();
	}

	public void castLightningBolt(RaycastHit2D hit){
		if (Input.GetKeyDown (KeyCode.Q)) {
			if (player.currentEnergy >= lightningBoltEnergy){
				LightningBoltScript lbScript = gameObject.GetComponentInChildren<LightningBoltScript>();
				lbScript.castLightningBolt(hit.transform);
			} else {
				print("not enougth energy");
			}
		}
	}
	
	public void castLightningChain(RaycastHit2D hit) {
		if (Input.GetKeyDown (KeyCode.W)) {
			if(player.currentEnergy >= lightningChainEnergy) {
				LightningBoltScript lbScript = gameObject.GetComponentInChildren<LightningBoltScript>();
				lbScript.castLightningBolt(hit.transform);
				
				// spawn chaining script to target
				Vector2 target = hit.point;
				
				// ignore first target for additional lightningchain (would chain itselfs)
				hit.rigidbody.gameObject.AddComponent<Hit>();

				Instantiate( lightningChainDetection, target, Quaternion.identity );
			} else {
				print("not enougth energy");
			}
		} 
	}

	public void castPowerDrain(RaycastHit2D hit) {
		if (Input.GetKey(KeyCode.E)) {
			if(player.currentEnergy >= powerDrainEnergy){
				PowerDrainScript pdScript = gameObject.GetComponentInChildren<PowerDrainScript>();
				pdScript.castPowerDrain(hit.transform);
			} else {
				print("not enougth energy");
			}
		}
	}

	public void castSpeedBoost() {
		if (Input.GetKeyDown (KeyCode.R)) {
			if(player.currentEnergy >= speedBoostEnergy){
				SpeedBoostScript sbScript = gameObject.GetComponentInChildren<SpeedBoostScript>();
				sbScript.castSpeedBoost();
			} else {
				print("not enougth energy");
			}
		}
	}
}
