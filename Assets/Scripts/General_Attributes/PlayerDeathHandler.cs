using UnityEngine;
using System.Collections;

public class PlayerDeathHandler : AbstractDeathHandler {
	
	/*
	 * Handle the player's death.
	 */
	public override void OnDeath() {
		Debug.Log("Player Dead!");
		Destroy(this.gameObject);
	}
}
