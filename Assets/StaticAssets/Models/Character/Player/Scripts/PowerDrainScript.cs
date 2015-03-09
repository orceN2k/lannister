using UnityEngine;
using System.Collections;

public class PowerDrainScript : MonoBehaviour {

	public float drainAmount = 10f;
	public float timeBetweenCast = 2f;

	private LineRenderer drainLine;
	private Transform hitTransform;
	private float timer;
	private Light drainLight;
	private RaycastHit2D shootHit;
	private float effectDisplayTime = 1f;




	void Awake() {
		drainLine = GetComponent<LineRenderer>();
//		drainLight = GetComponent<Light> ();
	}

	// Use this for initialization
	void Start () {
		drainLine.sortingLayerName = "Player";
	}
	
	// Update is called once per frame
	void Update () {
	
		timer += Time.deltaTime;
		
		if(timer >= timeBetweenCast * effectDisplayTime) {
			disableEffects ();
		}

		if (hitTransform != null) {
			drainLine.SetPosition (0, transform.position);


			for(int i =1; i < 3; i++)
			{
				var pos = Vector3.Lerp(this.transform.position, hitTransform.position, i/3.0f);
				
				pos.x += Random.Range(-0.2f,0.2f);
				pos.y += Random.Range(-0.2f,0.2f);
				
				drainLine.SetPosition(i,pos);
			}
			
			drainLine.SetPosition(3,hitTransform.position);

//			drainLine.SetPosition(1, hitTransform.position);
		}

	}

	public void disableEffects() {
		
		drainLine.enabled = false;
//		drainLight.enabled = false;
	}

	public void castPowerDrain(Transform hit) {

		hitTransform = hit;

		timer = 0f;
		
		drainLine.enabled = true;
		drainLine.SetPosition (0, transform.position);
		drainLine.SetPosition(1, hitTransform.position);


	}
}
