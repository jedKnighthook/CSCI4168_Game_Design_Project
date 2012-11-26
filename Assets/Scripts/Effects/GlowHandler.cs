using UnityEngine;
using System.Collections;

public class GlowHandler : MonoBehaviour {

	public bool startGlowActive = false;
	public GameObject glowEffect;
	
	void Start() {
		glowEffect.SetActiveRecursively(startGlowActive);
		if(glowEffect == null) {
			Debug.LogWarning("No glow effect object given.");	
		}
	}
	
	public void SetGlow(bool active) {
		if(glowEffect != null) {
			glowEffect.SetActiveRecursively(active);
		} else {
			Debug.LogWarning("Attempted to activate glow effect without providing a glow effect object.");	
		}
	}
	
	public bool GetGlow() {
		if(glowEffect != null) {
			return glowEffect.active;	
		} else {
			return false;
		}
	}
}
