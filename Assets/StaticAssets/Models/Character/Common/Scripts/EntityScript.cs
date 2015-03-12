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

	public void giveHealth(float addHealth) {
		if (currentHealth < maxHealth) {
			currentHealth += addHealth;
		}
		if (currentHealth > maxHealth){
			currentHealth = maxHealth;
		}
	}

	public void takeEnergy(float energy){
		if (currentEnergy > 0) {
			currentEnergy -= energy;
		}
		if (currentEnergy < 0){
			currentEnergy = 0;
		}
	}

	public void giveEnergy(float energy){
		if (currentEnergy < maxEnergy) {
			currentEnergy += energy;
		}
		if (currentEnergy > maxEnergy){
			currentEnergy = maxEnergy;
		}
	}
	
	public void die (){
		print ("player died!");
		Destroy (gameObject);
	}

	private void initEnergy () {
		currentEnergy = maxEnergy;
	}

	private void initHealth () {
		currentHealth = maxHealth;
	}

	private void regenerateHealth() {
		
		if (hasHealthRegeneration) {
			giveHealth(healthRegenerationRate / 1000);
		} 
	}

	private void regenerateEnergy() {
		
		if (hasEnergyRegeneration) {
			giveEnergy(energyRegenerationRate / 1000);
		} 
	}
}
