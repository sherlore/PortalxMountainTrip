using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traveller : MonoBehaviour {

	public bool inReality = true;
	public int worldIndex;
	public static Traveller instance;

	// Use this for initialization
	void Start () {
		Traveller.instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
