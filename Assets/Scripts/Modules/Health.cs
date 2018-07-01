using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	private HealthBar healthBar;
	
	public float maxHealth = 30;
    public float health = 30;

	public void Awake() {
		healthBar = GetComponentInChildren<HealthBar>();
	}

	public float getHealth() {
		return health;
	}

	public void setHealth(float h) {
		health = h;
		healthBar.set((health / maxHealth));
	}

	public float getMaxHealth() {
		return maxHealth;
	}

	public void setMaxhealth(float h) {
		maxHealth = h;
	}

	public void takeDamage(float damage) {
		if(health - damage > 0) {
			health -= damage;
		} else {
			health = 0;
		}

		healthBar.set(health / maxHealth);
	}
}
