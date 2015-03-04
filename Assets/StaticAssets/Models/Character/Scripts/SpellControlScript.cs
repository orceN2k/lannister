using UnityEngine;
using System.Collections;

public class SpellControlScript : MonoBehaviour {
	
	private GameObject lightningBolt;
	private GameObject createdLightningBolt;
	
	// Use this for initialization
	void Start () {
		lightningBolt = (GameObject)Resources.Load("fx_lightning_ll01");
	}
	
	// Update is called once per frame
	void Update () {


		Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
		Debug.DrawRay(transform.position, forward, Color.green);



//		GameObject target = GameObject.Find("EnemyHit");

//		Vector3 lightningVector = target.transform.position - transform.position;
//
//		print ("player: " + transform.position);
//		print ("target: " + target.transform.position);
//		print ("lightning: " + lightningVector);
		//Vector3 lightningBoltVector = spellOutPoint.transform.position - target.transform.position;

		//Quaternion rotation = Quaternion.LookRotation(lightningVector);



		// first spell
		if(Input.GetKeyDown(KeyCode.Q)){
//			createdLightningBolt = (GameObject) Instantiate(lightningBolt, lightningVector, Quaternion.Euler(0, 0, 90));
//			createdLightningBolt.transform.parent = transform;
		}
	}

	void FixedUpdate() {

	}

	private void killObject(GameObject destroyableObject){
		Destroy (destroyableObject);
	}
}
