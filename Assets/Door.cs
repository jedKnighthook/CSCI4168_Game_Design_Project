using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public Animation animationComponent;
	public AnimationClip doorOpenAnimation;
	public AnimationClip doorCloseAnimation;
	
	private float timeDoorOpened;
	public float timeDoorStaysOpen = 5f;
	private bool doorOpen = false;
	
	[ContextMenu("Test Interact")]
	void Interact(){
		TryOpenDoor();
	}
	
	void TryOpenDoor(){
		if(!doorOpen){
			doorOpen = true;
			animationComponent.Play(doorOpenAnimation.name);
			timeDoorOpened = Time.time; 
		}
	}
	
	void Update(){
		if(doorOpen && Time.time - timeDoorOpened > timeDoorStaysOpen){
			animationComponent.Play(doorCloseAnimation.name);
			StartCoroutine(WaitThenSetDoorClosed(doorCloseAnimation.length));
		}
	}
	
	IEnumerator WaitThenSetDoorClosed(float timeToWait){
		yield return new WaitForSeconds(timeToWait);
		doorOpen = false;
	}
	
}