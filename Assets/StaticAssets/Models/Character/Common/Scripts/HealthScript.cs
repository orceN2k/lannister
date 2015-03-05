using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public float maxHealth = 100f;
	public float currentHealth;
	public bool hasRegeneration = true;
	public float regenerationRate = 1f;
	
	void Start() {
		initHealth ();
	}
	
	void Update() {
		regenerateHealth ();
	}
	
	void initHealth () {
		currentHealth = maxHealth;
	}
	
	void regenerateHealth() {

		if (hasRegeneration) {
			if (currentHealth < maxHealth) {
				currentHealth += (maxHealth * (regenerationRate / 1000));
			} else if (currentHealth > maxHealth){
				currentHealth = maxHealth;
			}
		} 
	}
}
