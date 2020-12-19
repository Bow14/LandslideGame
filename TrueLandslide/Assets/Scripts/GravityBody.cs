using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour {

	// Initialize
	private Rigidbody rb;
	private Vector3 normal = Vector3.down;
	private Vector3 targetDirection = Vector3.down;
	private Quaternion targetRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
 
	private const float GRAVITY = -10.0f;
	private const float RAYDISTANCE = 15.0f;
	private const float ROTATIONSPEED = 0.15f;
 
	// When script initializes
	private void Awake() {
		rb = GetComponent<Rigidbody>();
	}
     
	// Physics update
	private void FixedUpdate() {
		// Set up ray to check the surface below player
		RaycastHit temp_hit;
		Ray temp_ray = new Ray(transform.position, -transform.up * RAYDISTANCE);
 
		// Gets the normal of the surface below the character, and also creates a target direction for gravity
		if (Physics.Raycast(temp_ray, out temp_hit)) {
			normal = temp_hit.normal;
			targetDirection = (transform.position - temp_hit.point).normalized;
		}
 
		// Finds desired rotation relative to surface normal
		targetRotation = Quaternion.FromToRotation(transform.up, normal) * transform.rotation;
 
		// Apply rotation and gravity
		transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, ROTATIONSPEED);
		rb.AddForce(targetDirection * GRAVITY);
		
	}
}
