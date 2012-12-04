using UnityEngine;
using System.Collections;

public abstract class AbstractDeathHandler : MonoBehaviour {
	
	/*
	 * Implementations of this method are to handle the
	 * death of any game object containing a health script.
	 */
	public abstract void OnDeath();
}
