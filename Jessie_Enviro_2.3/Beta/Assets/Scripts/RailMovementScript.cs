using UnityEngine;
using System.Collections;

public class RailMovementScript : MonoBehaviour {
	
	public CharacterController characterController;
	
	public float targetSpeed = 20;
	public float acceleration = 1;
	
	float currentSpeed;
	float pathPercent;
	float pastPercent;
	
	Vector3 pastPosition;
	
	CollisionFlags collisionFlags;
	
	void FixedUpdate() {
		if( Input.GetKey(KeyCode.LeftControl) == true )
		{
			currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, acceleration);
			MoveByDistance(currentSpeed * Time.deltaTime);
		}
		// I also call the methods related to vertical movement from here
		//
	}
	
	public void MoveByDistance(float distance)
	{
			MoveByPercent( distance / PlayerManager.GetPathLength() );
	}
	
	public void MoveByPercent(float delta)
	{	
		// Track percent and position from previous frame for collision
		pastPosition = transform.position;
		pastPercent = pathPercent;
			
		// Move our percentage along the path by delta
		pathPercent = Mathf.Clamp(pathPercent + delta, 0, 1);
	
		// Find target point on the path without the Y coordinate
		Vector3 target = iTween.PointOnPath(PlayerManager.GetCurrentPath(), pathPercent);
		target.y = transform.position.y;
	
		// Calculate the vector from the current position to the target
		Vector3 move = target - transform.position;
	
		// Move character controller, registering collision flags for collider logic
		collisionFlags = characterController.Move(move);
	}
}
