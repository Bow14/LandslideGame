using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravitional : MonoBehaviour
{

	private Rigidbody body; //Makes sure the rigidbody is only used on this script
	private Vector3 first = Vector3.down; // I believe this means that the vector 3 is alwasy pulling towards the ground
	private Vector3 direction = Vector3.down; //This means the direction of the vector 3 its going
	private Quaternion rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f); //Quaternion is used for rotation of the objects and 0.0f means no rotation


	private const float Grav = -10.0f; //Const means a constant float with no changes in its data
	private const float RayDistance = 15.0f;
	private const float RotationS = 0.15f; //float for the speed of rotation of object

	private void Awake()
	{
		body = GetComponent<Rigidbody>(); //This means on start or on awake the object with get the rigidbody componet
	}

	private void FixedUpdate() //Fixedupdate should always be used with physics and i think its just better or update
	{
		RaycastHit temp_hit; //Ray shoots a invisble line to find out its surroundings. used to find the surface to stick on
		Ray temp_ray = new Ray(transform.position, -transform.up * RayDistance);
		
		if (Physics.Raycast(temp_ray, out temp_hit)) //Shows were the surface is and creates where the direction should be for gravity
		{
			first = temp_hit.normal; // The surface the normal will hit
			direction = (transform.position - temp_hit.point).normalized;
		}

		rotation = Quaternion.FromToRotation(transform.up, first) * transform.rotation; // finds where the surface is and rotates to it
		//Applys the rotation and gravity to the situation 
		transform.rotation = Quaternion.Lerp(transform.rotation, rotation, RotationS);
		body.AddForce(direction * Grav);
	}

	
}
