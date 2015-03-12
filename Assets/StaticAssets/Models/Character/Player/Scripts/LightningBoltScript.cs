using UnityEngine;
using System.Collections;

public class LightningBoltScript : MonoBehaviour {

	public float damage = 20f;
	public float timeBetweenCast = 0.1f;
	public float energyCost = 10f;

	private float timer;
	private Transform hitTransform;
	private LineRenderer spellLine;
	private Light spellLight;
	private AudioSource spellAudio;
	private RaycastHit2D shootHit;
	private float effectDisplayTime = 1f;

	void Awake() {
		// get references
		spellLine = GetComponent<LineRenderer> ();
		spellLight = GetComponent<Light>();
		spellAudio = GetComponent<AudioSource>();
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

		if (hitTransform != null) {
			spellLine.SetPosition (0, transform.position);

			// add some lightning movement
			for(int i =1; i < 3; i++)
			{
				var pos = Vector3.Lerp(this.transform.position, hitTransform.position, i/3.0f);
				
				pos.x += Random.Range(-0.2f,0.2f);
				pos.y += Random.Range(-0.2f,0.2f);

				spellLine.SetPosition(i,pos);
			}
			spellLine.SetPosition(3,hitTransform.position);
		}

	}

	public void disableEffects() {

		spellLine.enabled = false;
		spellLight.enabled = false;
//		spellAudio.enabled = false;
	}
	
	public void castLightningBolt(Transform hit){
		
		hitTransform = hit;

		timer = 0f;

		spellLine.enabled = true;
		spellLine.SetPosition (0, transform.position);
		spellLine.SetPosition(3, hitTransform.position);

//		Debug.DrawLine (transform.position, hitTransform.position);

		spellLight.enabled = true;

		spellAudio.enabled = true;
		spellAudio.Play ();

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

		player.takeEnergy (10f);

//		enemy.takeDamage (damage);

	}
}
