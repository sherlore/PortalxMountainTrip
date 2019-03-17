using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour 
{
	public bool isReality;
	public GameObject gate;
	public int worldIndex;
	
	// Use this for initialization
	/*void Start () {
		
	}*/
	
	// Update is called once per frame
	/*void Update () {
		
		
	}*/
	
	public void SetWorldIndex(int val)
	{
		worldIndex = val;
	}
	
	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Player")
		{
			gate.SendMessage("StepInWindow", isReality);
		}
	}
	
	void OnTriggerExit(Collider col)
	{
		if(col.tag == "Player")
		{
			gate.SendMessage("StepOutWindow", isReality);
		}
	}
}
