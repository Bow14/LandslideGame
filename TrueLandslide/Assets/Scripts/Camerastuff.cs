using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerastuff : MonoBehaviour
{

	public Transform player;
	public Vector3 offset; //Vector three covers three floats used for position
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = player.position + offset; //camera will be equal to the players position 
	}
}
