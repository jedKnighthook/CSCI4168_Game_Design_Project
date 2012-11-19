using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour {
	
	
	public float rayDistance = 2.0f/3.0f;
	private Ray interaction;
	private RaycastHit hitInfo;
	
	// Update is called once per frame
	void Update () {
		interaction = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
		if(Physics.Raycast (interaction, out hitInfo, rayDistance)) {
			if(hitInfo.transform.gameObject.GetComponent<Interactable>()) {
				Debug.Log ("Object interactable");
			}
		}
	}
}
