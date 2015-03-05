using UnityEngine;
using System.Collections;

public class LightningChainScript : MonoBehaviour {
	
	public float enemyRestruckDelay = 1f;
	private GameObject lightningBoltCircle;

	void Start() {
		lightningBoltCircle = (GameObject)Resources.Load("lightningChainRangeDetection");
	}

	void OnTriggerEnter2D(Collider2D other) {

		Enemy enemy = other.gameObject.GetComponent<Enemy>();
		
		if( enemy == null ) {  // It is not enemy
			return;
		}
		
		Hit hit = other.gameObject.GetComponent<Hit>();
		
		if( hit == null ) { // the enemy is yet to be hit
			
			//Call you lightning strike effect here
			LightningBoltAnimationScript lb = other.gameObject.AddComponent<LightningBoltAnimationScript>();
			lb.castLightningBolt(transform, other.transform);

			//Create another copy of this lightning field, by doing this, it will start chaining when the condition is right
			Instantiate( lightningBoltCircle, other.gameObject.transform.position, Quaternion.identity );
			
			//Mark the enemy as hit
			hit = other.gameObject.AddComponent<Hit>();
			
			hit.killDelay = enemyRestruckDelay;
			
			//Kill this gameObject once you have struck the closest enemy
			//Remove the Kill() if you want to strike everyone in the proximity
			Kill();
		}
	}
	
	//Call this using an animation event, just in case the sphere strike nothing at all
	void Kill() {
		Destroy(gameObject);
	}
}
