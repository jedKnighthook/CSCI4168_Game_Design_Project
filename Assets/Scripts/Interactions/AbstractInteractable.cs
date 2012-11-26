using UnityEngine;
using System.Collections;

public abstract class AbstractInteractable : MonoBehaviour {

	public abstract void OnInteract();
	public abstract void OnInteractStop();
	public abstract void OnHover();
	public abstract void OnHoverStop();
	
}
