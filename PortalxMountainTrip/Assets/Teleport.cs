using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

	public Vector3[] spots;
	public int index;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetButtonDown("Jump") )
		{
			if(index != spots.Length-1)
			{
				index++;
			}
			else
			{
				index = 0;
			}
			transform.position = spots[index];
		}
		
		if(Input.GetButtonDown("Fire2") )
		{
			spots[index] = transform.position;
		}
	}
}
