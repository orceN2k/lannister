using UnityEngine;
using System.Collections;

public class CharacterBarScript : MonoBehaviour {

	public Texture2D backgroundTexture;
	public Texture2D healthTexture;
	public Texture2D energyTexture;

	private EntityScript entity;

	private float healthBarLength;
	private float energyBarLength;

	void Awake() {
		entity = GetComponentInParent<EntityScript>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){
		Vector2 targetPos;
		targetPos = Camera.main.WorldToScreenPoint (transform.position);

		float currentHealth = Mathf.Round (entity.currentHealth * 100f) / 100f;
		float currentEnergy = Mathf.Round (entity.currentEnergy * 100f) / 100f;

//		GUI.DrawTexture (new Rect (targetPos.x - 200, Screen.height - 200, 400, 250), backgroundTexture, ScaleMode.ScaleToFit, true, 1.0F);
//		GUI.DrawTexture(new Rect(targetPos.x - 110, targetPos.y, 220, 20), healthTexture, ScaleMode.StretchToFill, true, 1.0F);
		GUI.Label (new Rect (targetPos.x - 25, targetPos.y - 40, 50, 20), currentHealth + "/" + entity.maxEnergy);
//		GUI.DrawTexture(new Rect(targetPos.x - 110, targetPos.y, 220, 20), energyTexture, ScaleMode.StretchToFill, true, 1.0F);
		GUI.Label (new Rect (targetPos.x - 25, targetPos.y - 20, 50, 20), currentEnergy + "/" + entity.maxEnergy);
	}

}
