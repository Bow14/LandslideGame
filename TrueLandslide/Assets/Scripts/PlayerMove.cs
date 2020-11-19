using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
//tutorial script to learn new gaming designs

	public Rigidbody rb;
	// Use this for initialization
	
	
	// Update is called once per frame
	void FixedUpdate () //fixedupdate is used for physics properties
	{ 
		rb.AddForce(0, 0, 2000 * Time.deltaTime);// time. delta time is used so the game speed and such doesnt run off frames of the pc
	}
}
