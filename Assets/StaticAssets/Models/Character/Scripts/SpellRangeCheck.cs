using UnityEngine;
using System.Collections;

public class SpellRangeCheck : MonoBehaviour {

	public Transform lightningBoltLinecastEnd;
	public bool lightningBoltEnable = false;
	public bool lightningSphereEnable = false;
	public float xOffset = 0f;
	public float yOffset = 0f;

	private GameObject lightningBolt;
	private GameObject createdLightningBolt;
	
	// Use this for initialization
	void Start () {
		lightningBolt = (GameObject)Resources.Load("fx_lightning_ll01");
	}
	
	// Update is called once per frame
	void Update () {
		Raycast ();
	}

	void Raycast() {

//		RaycastHit2D hit = Physics2D.Raycast (transform.position, transform.right, 4f, 1 << LayerMask.NameToLayer ("Enemy"));
		RaycastHit2D hit = Physics2D.Linecast (transform.position, lightningBoltLinecastEnd.position, 1 << LayerMask.NameToLayer ("Enemy"));
		if (hit.collider != null) {
			if (Input.GetKeyDown(KeyCode.Q)) {


				Vector2 player = new Vector2(transform.position.x, transform.position.y);
				Vector2 target = hit.point;

				Vector2 spellVectorCalc = target - player;
				float distance = spellVectorCalc.magnitude;

				Vector2 direction = spellVectorCalc / distance;

				print ("player: " + transform.position);
				print ("target: " + target);
				print ("spellVector" + spellVectorCalc);
				print ("distance: " + distance);
				print ("direction: " + direction);



//				spellVector.x *= xOffset;
//				spellVector.y *= yOffset;
//				spellVector.

				createdLightningBolt = (GameObject) Instantiate(lightningBolt, player , Quaternion.Euler(0, 0, 90));
				Vector3 newScale = new Vector3(4, distance * direction.x, 0);
				Vector3 newPosition = new Vector3(player.x + (distance / 2) * direction.x, player.y, 0);
				createdLightningBolt.transform.localScale = newScale;
				createdLightningBolt.transform.position = newPosition;
				createdLightningBolt.transform.parent = transform;
				Destroy(createdLightningBolt, 0.2f);

			}
			Debug.DrawLine (transform.position, hit.point, Color.red);
		}
	}
}
