using UnityEngine;
using System.Collections;

public class EntityScript : MonoBehaviour {

	public float maxEnergy = 100f;
	public float currentEnergy;
	public bool hasEnergyRegeneration = true;
	public float energyRegenerationRate = 1f;
	public float maxHealth = 100f;
	public float currentHealth;
	public bool hasHealthRegeneration = true;
	public float healthRegenerationRate = 1f;

	void Awake () {
		initHealth ();
		initEnergy ();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		regenerateHealth ();
		regenerateEnergy ();	
	}

	public void takeDamage(float dmg) {
		currentHealth -= dmg;

		if (currentHealth <= 0) {
			die();
		}
	}

	public void takeEnergy(float energy){
		currentEnergy -= energy;
	}

	public void die (){
		print ("player died!");
	}

	private void initEnergy () {
		currentEnergy = maxEnergy;
	}

	private void initHealth () {
		currentHealth = maxHealth;
	}

	private void regenerateHealth() {
		
		if (hasHealthRegeneration) {
			if (currentHealth < maxHealth) {
				currentHealth += (maxHealth * (healthRegenerationRate / 1000));
			} else if (currentHealth > maxHealth){
				currentHealth = maxHealth;
			}
		} 
	}

	private void regenerateEnergy() {
		
		if (hasEnergyRegeneration) {
			if (currentEnergy < maxEnergy) {
				currentEnergy += (maxEnergy * (energyRegenerationRate / 1000));
			} else if (currentEnergy > maxEnergy){
				currentEnergy = maxEnergy;
			}
		} 
	}


}
