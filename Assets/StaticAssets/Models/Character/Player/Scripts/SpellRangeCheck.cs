﻿using UnityEngine;
using System.Collections;

public class SpellRangeCheck : MonoBehaviour {

	public Transform lightningBoltLinecastEnd;
	public bool lightningBoltEnable = false;
	public bool lightningChainEnable = false;
	
	private GameObject lightningChainDetection;
	
	// Use this for initialization
	void Start () {
		lightningChainDetection = (GameObject)Resources.Load("lightningChainRangeDetection");
	}
	
	// Update is called once per frame
	void Update () {
		Raycast ();
	}

	void Raycast() {

		RaycastHit2D hit = Physics2D.Linecast (transform.position, lightningBoltLinecastEnd.position, 1 << LayerMask.NameToLayer ("Enemy"));
		if (hit.collider != null) {

			// call SpellControlScript
			SpellControlScript scScript = gameObject.GetComponent<SpellControlScript>();
			scScript.castLightningBolt(hit);
			scScript.castLightningChain(hit);

			// draw line to target
			Debug.DrawLine (transform.position, hit.point, Color.red);
		}
	}

//	void LightningBolt(RaycastHit2D hit){
//		if (Input.GetKeyDown (KeyCode.Q)) {
//
//			// cast lightningbolt to target
//			LightningBoltAnimationScript lb = hit.rigidbody.gameObject.AddComponent<LightningBoltAnimationScript>();
//			lb.castLightningBolt(transform, hit.transform);
//		}
//	}
//
//	void LightningChain(RaycastHit2D hit) {
//		if (Input.GetKeyDown (KeyCode.W)) {
//
//			// cast lightningbolt to target
//			LightningBoltAnimationScript lb = hit.rigidbody.gameObject.AddComponent<LightningBoltAnimationScript>();
//			lb.castLightningBolt(transform, hit.transform);
//
//			// spawn chaining script to target
//			Vector2 target = hit.point;
//			Instantiate( lightningChainDetection, target, Quaternion.identity );
//		} 
//	}
}
