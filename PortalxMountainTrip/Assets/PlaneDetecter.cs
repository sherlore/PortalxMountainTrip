using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneDetecter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnEnable()
	{
        if (GameConsole.console)
            GameConsole.console.SendMessage("SetPlaneFound", true);
    }

    private void OnDisable()
    {
        if (GameConsole.console)
            GameConsole.console.SendMessage("SetPlaneFound", false);
    }
}
