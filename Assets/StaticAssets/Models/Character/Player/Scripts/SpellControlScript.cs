using UnityEngine;
using System.Collections;

public class SpellControlScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		// first spell
		if(Input.GetKeyDown(KeyCode.Q)){
//			createdLightningBolt = (GameObject) Instantiate(lightningBolt, lightningVector, Quaternion.Euler(0, 0, 90));
//			createdLightningBolt.transform.parent = transform;
		}
	}

	void FixedUpdate() {

	}

	private void killObject(){
		Destroy (gameObject);
	}
}
