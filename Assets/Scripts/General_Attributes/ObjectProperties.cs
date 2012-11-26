using UnityEngine;
using System.Collections;

public class ObjectProperties : MonoBehaviour {
	
	/*
	 * Public variables
	 * These are settings to be set in the unity editor to
	 * set up a new player or NPC
	 */
	public float startingMaxHealth;
	public float startingMaxStamina;
	
	public float startingHealthRegen;
	public float startingStaminaRegen;
	
	public AbstractDeathHandler deathHandler;
	
	/*
	 * Private variables
	 */
	private float maxHealth;
	private float currentHealth;
	private float healthRegen;
	
	private float maxStamina;
	private float currentStamina;
	private float staminaRegen;
	
	/*
	 * Callback Methods
	 */
	void Start () {
		maxHealth = startingMaxHealth;
		currentHealth = maxHealth;
		healthRegen = startingHealthRegen;
		
		maxStamina = startingMaxStamina;
		currentStamina = maxStamina;
		staminaRegen = startingStaminaRegen;
		
	}
	
	void OnGUI()
	{
		if (Application.isEditor)  // or check the app debug flag
		{
			GUI.Label(new Rect(5, 5, 400, 20), "HP: " + currentHealth + ", +" + healthRegen + " hp/sec");
		}
	}
	
	void Update () {
		
		/*
		 * Check to see each frame if the entity's health is less than or equal
		 * to zero. If so, the entity dies and the function returns so that
		 * they will not regenerate back to life.
		 */
		if(currentHealth <= 0.0f) {
		
			if(deathHandler != null) {
				deathHandler.OnDeath();
				return;
			} else {
				System.Console.WriteLine("Object dead; No DeathHandler attached");	
			}
		}
		
		/*
		 * Update healh and stamina based on time passed only if they
		 * are still alive at this point.
		 */
		currentHealth += healthRegen * Time.deltaTime;
		if(currentHealth > maxHealth) {
			currentHealth = maxHealth;	
		}
		
		currentStamina += staminaRegen * Time.deltaTime;
		if(currentStamina > maxStamina) {
			currentStamina = maxStamina;	
		}
	}
	
	
	/*
	 * Health Accessors
	 */
	public void SetHealth(float health) {
		currentHealth = health;
	}
	public void AddHealth(float health) {
		currentHealth += health;	
	}
	public float GetHealth() {
		return currentHealth;	
	}
	
	/*
	 * Health Regen Accessors
	 */
	public void SetHealthRegen(float regen) {
		healthRegen = regen;	
	}
	public void AddHealthRegen(float regen) {
		healthRegen += regen;	
	}
	public float GetHealthRegen() {
		return healthRegen;	
	}

	/*
	 * Stamina Accessors
	 */
	public void SetStamina(float stamina) {
		currentStamina = stamina;
	}
	public void AddStamina(float stamina) {
		currentStamina += stamina;	
	}
	public float GetStamina() {
		return currentStamina;	
	}
	
	/*
	 * Stamina Regen Accessors
	 */
	public void SetStaminaRegen(float regen) {
		staminaRegen = regen;
	}
	public void AddStaminaRegen(float regen) {
		staminaRegen += regen;	
	}
	public float GetStaminaRegen() {
		return staminaRegen;	
	}
}
