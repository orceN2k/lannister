using UnityEngine;
using System.Collections;

public class LightningBoltScript : MonoBehaviour {
	
	public float timeBetweenCast = 0.1f;

	float timer;
	private LineRenderer spellLine;
	private Light spellLight;
	private RaycastHit2D shootHit;
	private float effectDisplayTime = 1f;

	void Awake() {
		// get references
		spellLine = GetComponent<LineRenderer> ();
		spellLight = GetComponent<Light>();
	}


	// Use this for initialization
	void Start () {
		spellLine.sortingLayerName = "Player";
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		if(timer >= timeBetweenCast * effectDisplayTime) {
			disableEffects ();
		}

	}

	public void disableEffects() {

		spellLine.enabled = false;
		spellLight.enabled = false;
	}
	
	public void castLightningBolt(Vector2 hitPoint){

		timer = 0f;

		spellLine.enabled = true;
		spellLine.SetPosition (0, transform.position);
		spellLine.SetPosition(1, hitPoint);

		Debug.DrawLine (transform.position, hitPoint);

		spellLight.enabled = true;
	}
}
