using UnityEngine;
using System.Collections;

public class PowerDrainScript : MonoBehaviour {

	public float drainAmount = 0.0001f;
	public float timeBetweenCast = 0.01f;
	public float energyCost = 0f;

	private LineRenderer drainLine;
	private Transform hitTransform;
	private float timer;
	private Light drainLight;
	private AudioSource drainAudio;
	private RaycastHit2D shootHit;
	private float effectDisplayTime = 0.2f;


	void Awake() {
		drainLine = GetComponent<LineRenderer>();
		drainLight = GetComponent<Light> ();
		drainAudio = GetComponent<AudioSource>();
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

			for(int i = 1; i < 3; i++) {
				var pos = Vector3.Lerp(this.transform.position, hitTransform.position, i/3.0f);
				
				pos.x += Random.Range(-0.2f,0.2f);
				pos.y += Random.Range(-0.2f,0.2f);
				
				drainLine.SetPosition(i, pos);
			}
			drainLine.SetPosition(3, hitTransform.position);
		}

	}

	public void disableEffects() {
		
		drainLine.enabled = false;
		drainLight.enabled = false;
//		drainAudio.enabled = false;
	}

	public void castPowerDrain(Transform hit) {

		hitTransform = hit;

		timer = 0f;

		drainAudio.enabled = true;
		drainAudio.Play ();

		drainLight.enabled = true;
		drainLine.enabled = true;
		drainLine.SetPosition (0, transform.position);
		drainLine.SetPosition(3, hitTransform.position);

		Enemy enemy = hitTransform.GetComponent<Enemy> ();
		
		if (enemy == null) {
			print ("enemy not found");
			return;
		}
		
		Player player = transform.gameObject.GetComponentInParent<Player>();
		
		if (player == null) {
			print ("player not found");
			return;
		}
		
		player.giveEnergy (0.01f);



	}
}
