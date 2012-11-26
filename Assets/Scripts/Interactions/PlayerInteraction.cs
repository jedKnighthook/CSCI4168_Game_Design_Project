using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour {
	
	private AbstractInteractable lastInteractable;
	private AbstractInteractable interactable;
	
	public float rayDistance = 2.0f/3.0f;
	private Ray interaction;
	private RaycastHit hitInfo;
	
	// Update is called once per frame
	void Update () {
		// Remember the last interactable thing the player was looking at
		lastInteractable = interactable;
		
		// Look for the current interactable thing under the player's view
		interaction = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
		if(Physics.Raycast (interaction, out hitInfo, rayDistance)) {
			interactable = hitInfo.transform.gameObject.GetComponent<AbstractInteractable>();
			if(interactable) {
				// If we are looking at something for the first time call OnHover()
				if(lastInteractable != interactable) {
					Debug.Log("OnHover()");
					interactable.OnHover();
				}
				
				// If we are looking at something and pressing the interaction button call OnInteract()
				if(Input.GetKey(KeyCode.E)) {
					Debug.Log("OnInteract()");
					interactable.OnInteract();
				}
			} else {
				// If we found something non interactive set interactable to null
				interactable = null;
				Debug.Log("NonInteractable -> null");
			}
		} else {
			// If we didn't find anything in our view at all set interactable to null
			interactable = null;
			Debug.Log("Nothing Found -> null");
		}
		
		// If we were looking at an interactable and stopped call OnHoverStop
		if(lastInteractable && lastInteractable != interactable) {
			lastInteractable.OnHoverStop();
			
		}
	}
}
