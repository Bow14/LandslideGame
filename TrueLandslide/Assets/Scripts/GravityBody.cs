using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour {

// This is not my script this is made by a dude named harperrhett https://answers.unity.com/questions/443938/whats-a-good-way-to-keep-a-character-connected-to.html
//I will be studying this code and remaking it to my own i just wanted to see if this was the answer to my problem but that will be for tomorrow.
// Just wanted to clarify so i dont get like punished or anything
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
