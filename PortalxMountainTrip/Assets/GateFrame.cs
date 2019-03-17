using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateFrame : MonoBehaviour {

	public Renderer windowReality;
	public Renderer windowVirtual;

	void OnDisable()
	{
		windowReality.enabled = false;
		windowVirtual.enabled = true;
	}
}
