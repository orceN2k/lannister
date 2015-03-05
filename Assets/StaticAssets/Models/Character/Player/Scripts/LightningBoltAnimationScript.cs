using UnityEngine;
using System.Collections;

public class LightningBoltAnimationScript : MonoBehaviour {

	private GameObject lightningBolt;

	public void castLightningBolt(Transform origin, Transform target){

		lightningBolt = (GameObject)Resources.Load("fx_lightning_ll01");

		print (origin);
		print (target);

		Vector2 originVector = new Vector2 (origin.position.x, origin.position.y);
		Vector2 targetVector = new Vector2 (target.position.x, target.position.y);
		
		Vector2 spellVector = targetVector - originVector;
		float distance = spellVector.magnitude;
		
		Vector2 direction = spellVector / distance;
		
		GameObject createdLightningBolt = (GameObject)Instantiate (lightningBolt, spellVector, Quaternion.Euler (0, 0, 90));
		Vector3 newScale = new Vector3 (4, distance * direction.x, 0);
		Vector3 newPosition = new Vector3 (origin.position.x + (distance / 2) * direction.x, origin.position.y, 0);
		createdLightningBolt.transform.localScale = newScale;
		createdLightningBolt.transform.position = newPosition;
		createdLightningBolt.transform.parent = transform;
		Destroy (createdLightningBolt, 0.2f);
		Destroy (this);

	}
}
