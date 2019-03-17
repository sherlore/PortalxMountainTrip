using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class InterdimensionalTransport : MonoBehaviour {

    public bool startInReality;
	public Material[] materials;
	public bool inReality = true;
	public bool onRealityTrigger;
	public bool onVirtualTrigger;
	public Renderer[] windowReality;
	public Renderer[] windowVirtual;
	public GameObject gate;
	public int worldIndex;
	
	public Material ARBackground;

    public GameObject bonusC;

	// Use this for initialization
	void Start () {
		// StartCoroutine(initEnvironment());
        if(startInReality)
            EnterReality();
        else
            EnterVirtual();
	}
	
	// Update is called once per frame
	/*void Update () {
		
	}*/
	
	/*public void SetWorldIndex()
	{
		foreach(Material mat in materials)
		{
			mat.SetInt("_MaskRef", worldIndex);
		}
		windowReality.SendMessage("SetWorldIndex", worldIndex);
		windowVirtual.SendMessage("SetWorldIndex", worldIndex);
	}*/
	
	/*IEnumerator initEnvironment () 
	{
		SetWorldIndex();
		while(Traveller.instance == null)
		{
			Debug.Log("Delay Init");
			yield return new WaitForSeconds(0.1f);
		}
		// EnterReality();
        EnterVirtual();
	}*/
	
	
	/*public void StepInWindow(bool isReality)
	{
		if(isReality)
		{
			onRealityTrigger = true;
			if(!Traveller.instance.inReality && onVirtualTrigger)
			{
				// Debug.Log("");
				EnterReality();
			}
		}
		else
		{
			onVirtualTrigger = true;
			if(Traveller.instance.inReality  && onRealityTrigger)
			{
				EnterVirtual();
			}
		}
	}
		
	
	public void StepOutWindow(bool isReality)
	{
		if(isReality)
		{
			onRealityTrigger = false;
			if(Traveller.instance.inReality  && onVirtualTrigger)
			{
				EnterVirtual();
			}
		}
		else
		{
			onVirtualTrigger = false;
			if(!Traveller.instance.inReality  && onRealityTrigger)
			{
				EnterReality();
			}
		}
	}	*/
	
	void OnTriggerEnter(Collider col)
	{
		if(col.name == "Reality Window")
		{
            Debug.Log("Reality Window");
			onRealityTrigger = true;
			if(!inReality && onVirtualTrigger)
			{
				// Debug.Log("");
				EnterReality();
			}
		}
		else if(col.name == "Virtual Window")
        {
            Debug.Log("Virtual Window");
			onVirtualTrigger = true;
			if(inReality && onRealityTrigger)
			{
				EnterVirtual();
			}
		}
	}
	
	void OnTriggerExit(Collider col)
	{
		if(col.name == "Reality Window")
        {
            Debug.Log("Reality Window");
			onRealityTrigger = false;
			if(inReality && onVirtualTrigger)
			{
				EnterVirtual();
			}
		}
		else if(col.name == "Virtual Window")
        {
            Debug.Log("Virtual Window");
			onVirtualTrigger = false;
			if(!inReality && onRealityTrigger)
			{
				EnterReality();
			}
		}
	}
	
	public void EnterVirtual()
	{
		Debug.Log("EnterVirtual");
		// Traveller.instance.inReality  = false;
		
		inReality = false;
		windowReality[GameConsole.gateIndex].enabled = true;
		windowVirtual[GameConsole.gateIndex].enabled = false;
		foreach(Material mat in materials)
		{
			mat.SetInt("_StencilTest", (int)CompareFunction.NotEqual);
		}
		
		if(ARBackground == null)
		{
			GameObject video = GameObject.Find("BackgroundPlane");
			if(video == null) return;
			Renderer videoRenderer = video.GetComponent<Renderer>();
			ARBackground = videoRenderer.material;
		}
		
		if(ARBackground)
		{
			ARBackground.SetInt("_StencilTest", (int)CompareFunction.Equal);
		}
		
        // gate.BroadcastMessage("ReceiveShadow", true);
        bonusC.SetActive(false);
	}
	
	public void EnterReality()
	{
		Debug.Log("EnterReality");
		// Traveller.instance.inReality  = true;
		
		inReality = true;
		windowReality[GameConsole.gateIndex].enabled = false;
		windowVirtual[GameConsole.gateIndex].enabled = true;
		foreach(Material mat in materials)
		{
			mat.SetInt("_StencilTest", (int)CompareFunction.Equal);
		}
		
		if(ARBackground == null)
		{
			GameObject video = GameObject.Find("BackgroundPlane");
			if(video == null) return;
			Renderer videoRenderer = video.GetComponent<Renderer>();
			ARBackground = videoRenderer.material;
		}
		
		if(ARBackground)
		{
			ARBackground.SetInt("_StencilTest", (int)CompareFunction.NotEqual);
		}

        // gate.BroadcastMessage("ReceiveShadow", false);

        bonusC.SetActive(true);
	}
}
