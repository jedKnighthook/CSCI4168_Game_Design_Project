using UnityEngine;
using System.Collections;

public class FPSMove : MonoBehaviour {
	//walking vars
	public float walk_speed = 5;
	public float run_multiplier = 2;
	public float crouch_multiplier = 0.5f;
	private float last_forward = -1.0F;
	private bool running = false;
	
	//jumping vars
	public float jump_height = 400;
	public float gravity = 98.1f;
	private bool grounded = true;
	private bool jumping = false;
	private float move_y;
	
	//crouching vars
	public float crouch_height = 0.5f;
	private float normal_height;
	private bool crouching = false;
	
	//character movement vars
	public Vector3 MoveDirection = Vector3.zero;
	public CharacterController Controller;
		
	void Start() {
		normal_height = Controller.height;	
	}
	
	// Update is called once per frame
	void Update () {
		//handle running
		if(Input.GetKeyUp(KeyCode.W)) {
			last_forward = Time.time;
			running = false;
		}
		if(Input.GetKeyDown (KeyCode.W)) {
			if(Time.time - last_forward < 0.2F) {
				running = true;
			}
			last_forward = Time.time;
		}
		
		//handle crouching
		if(Input.GetKeyDown (KeyCode.LeftShift)) {
			Controller.height = Controller.height * crouch_height;
			Vector3 temp = this.transform.position;
			temp.y -= Controller.height * crouch_height + 0.5f;
			
			crouching = true;
			running = false;
		}
		if(Input.GetKeyUp (KeyCode.LeftShift)) {
			Controller.height = normal_height;
			crouching = false;
			Vector3 temp = this.transform.position;
			temp.y += Controller.height * crouch_height + 6.5f;
			this.transform.position = temp;
		}
		
		//movement
		Vector3 forward = -Camera.main.transform.forward;
		Vector3 movement_vector;
		forward = forward.normalized;
		RaycastHit ground;
		if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out ground, Controller.height+6.5f)) {
			Vector3 ground_normal = ground.normal.normalized;
			movement_vector = Vector3.Cross(Vector3.Cross(ground_normal, forward), ground_normal).normalized;
			Debug.Log ("in here...");
		} else {
			movement_vector = forward;
		}
		movement_vector *= Camera.main.transform.forward.magnitude;
		
		
		
		MoveDirection = movement_vector * Input.GetAxis("Vertical") - Camera.main.transform.right * Input.GetAxis ("Horizontal");
		MoveDirection = transform.TransformDirection(MoveDirection);
		//Move the player by the walk speed
		MoveDirection *= walk_speed;
		//if the player is running multiply by the multiplier
		if(crouching) MoveDirection *= crouch_multiplier;
		else if(running) MoveDirection *= run_multiplier;
		if(grounded) if(Input.GetKey(KeyCode.Space)) jumping = true;
		//jumping, etc
		if(jumping) MoveDirection.y += jump_height*Time.deltaTime;		
		move_y -= gravity * Time.deltaTime;
		MoveDirection.y += move_y;
		CollisionFlags flags = Controller.Move(MoveDirection * Time.deltaTime);
		grounded = (flags & CollisionFlags.CollidedBelow) != 0;
		if(grounded) {
			move_y = 0;
			jumping = false;
		}
	}
}
