using UnityEngine;
using System.Collections;

public class FPSLook : MonoBehaviour {
	
	public float rotate_speed = 5;
	
	private float rotationX = 0F;
    private float rotationY = 0F;
	
	private float maxY = 75F;
	private float minY = -75F;
	
	// Update is called once per frame
	void Update () {
		
		Screen.lockCursor = true;
		//pulled from the Player Move Script on the default AngryBots game
		Screen.showCursor = (Input.mousePosition.x < 0 || Input.mousePosition.x > Screen.width || Input.mousePosition.y < 0 || Input.mousePosition.y > Screen.height);
		//get the X and Y rotation
		rotationX = Input.GetAxis("Mouse X") * rotate_speed;
        rotationY += Input.GetAxis("Mouse Y") * rotate_speed;
		//Check if the Y rotation exceeds the min and max vertical direction
		rotationY = Mathf.Clamp(rotationY, minY, maxY);
		
		//perform the X rotation then the Y
		transform.Rotate(0,rotationX, 0);
		transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y,0);
	}
}
