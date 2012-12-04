using UnityEngine;
using System.Collections;

public class WeaponInteractable : AbstractInteractable {
	
	public GameObject weapon;
	private GlowHandler glowHandler;
	
	private bool hover = false;
	private bool interact = false;
	private bool glow = false;
	
	void Start() {
		glowHandler = weapon.GetComponent<GlowHandler>();
	}
	
	public override void OnInteract() {
		// Pick up weapon
	}
	
	public override void OnInteractStop() {
		
	}
	
	public override void OnHover() {
		if(glowHandler) {
			glowHandler.SetGlow(true);
		}
	}
	
	public override void OnHoverStop() {
		if(glowHandler) {
			glowHandler.SetGlow(false);
		}	
	}
	
	void OnGUI()
	{
		if (Application.isEditor)
		{
			GUI.Label(new Rect(5, 25, 400, 20), "Hover: " + hover + " | Interact: " + interact + " | Glow: " + glowHandler.GetGlow());
		}
	}
	
}
