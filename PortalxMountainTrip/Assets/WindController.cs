using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour {

	public WindZone myWind;
	public Vector2 windChangePeriod;
	public float randSeedScale;
	public float randSeedOffset;
	
	
	// Use this for initialization
	void Start () 
	{
		Invoke("RandomWind", Random.Range(windChangePeriod.x, windChangePeriod.y));
	}
		
	public void RandomWind()
	{
		Vector2 randSeed = Random.insideUnitCircle * randSeedScale;
		float newWindMain = Mathf.Clamp01(randSeed.y + randSeedOffset);
		myWind.windMain = newWindMain;
		
		Debug.Log("Set wind to " + newWindMain);
		Invoke("RandomWind", Random.Range(windChangePeriod.x, windChangePeriod.y));
	}
}
