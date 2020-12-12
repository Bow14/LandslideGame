using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
//tutorial script to learn new gaming designs

	public Rigidbody rb;

	public float forwardForce = 2000f;
	public float sidwaysForce = 500f;
	
	// Update is called once per frame
	void FixedUpdate () //fixedupdate is used for physics properties
	{ 
		rb.AddForce(0, 0, forwardForce * Time.deltaTime);// time. delta time is used so the game speed and such doesnt run off frames of the pc

		if (Input.GetKey("d"))
		{
			rb.AddForce(sidwaysForce * Time.deltaTime, 0,0, ForceMode.VelocityChange);
		}
		if (Input.GetKey("a"))
		{
			rb.AddForce(-sidwaysForce * Time.deltaTime, 0,0, ForceMode.VelocityChange);
		}

		if (rb.position.y < -1f)
		{
			FindObjectOfType<GameManger>().EndGame();
		}
	}
}
