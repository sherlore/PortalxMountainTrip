using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonExtra : MonoBehaviour {

    public Button myButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(Input.GetAxis("Vertical") > 0.1f)
        {
            myButton.interactable = true;
        }
        else if(Input.GetAxis("Vertical") < 0f || Input.GetAxis("Horizontal") != 0)
        {
            myButton.interactable = false;
        }
	}
}
