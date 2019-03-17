using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInvoke : MonoBehaviour {

    public Button myButton;
    public string inputName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(myButton.interactable && Input.GetButtonDown(inputName))
        {
            myButton.onClick.Invoke();
        }
	}
}
