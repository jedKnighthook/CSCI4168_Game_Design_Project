using UnityEngine;
using System.Collections;

public class FPSMove : MonoBehaviour {

	public float walk_speed = 5;
	public float jump_height = 400;
	public float run_speed = 2;
	
	public float gravity = 980;
	
	public Vector3 MoveDirection = Vector3.zero;
	public CharacterController Controller;
		
	private Vector3 camera_forward;
	private Vector3 camera_right;
	private bool grounded = true;
	private float ground_distance;
	private float last_forward = -1.0F;
	private bool running = false;
	
	void Start() {

	}
	
	// Update is called once per frame
	void Update () {
		MoveDirection = Camera.main.transform.forward * Input.GetAxis("Vertical") + Camera.main.transform.right * Input.GetAxis ("Horizontal");
		MoveDirection = transform.TransformDirection(MoveDirection);
		if(grounded) {
			MoveDirection *= walk_speed;
			if(Input.GetKey(KeyCode.Space))
				this.rigidbody.AddForce(Vector3.up * jump_height);
			
		}
		
		MoveDirection.y -= gravity * Time.deltaTime;
		CollisionFlags flags = Controller.Move(MoveDirection * Time.deltaTime);
		grounded = (flags & CollisionFlags.CollidedBelow) != 0;
		
		/*
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		float current_run_speed = 1;
		
		Vector3 current = this.transform.position;
		
		camera_forward = Camera.main.transform.forward;
		camera_right = Camera.main.transform.right;
		camera_forward.y = 0;
		
		//jumping code
		if (Input.GetKeyDown(KeyCode.Space) && this.rigidbody) {
			if(Physics.Raycast(transform.position, -Vector3.up, ground_distance + 0.1F)) {
				this.rigidbody.AddForce(Vector3.up * jump_height);
			}
		}
		
		//running code (forward only)
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
		
		if(running) current_run_speed = run_speed;
			
		//current += (camera_right * horizontal + camera_forward * vertical * current_run_speed) * walk_speed * Time.deltaTime;
		//this.transform.position = current;
		
		
		this.rigidbody.AddForce ((camera_right * horizontal + camera_forward * vertical * current_run_speed) * walk_speed * Time.deltaTime);
		*/
	}
}
