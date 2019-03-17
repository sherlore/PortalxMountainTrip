using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAxisInvoke : MonoBehaviour {

    public Button myButton;
    public bool usePositive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (usePositive && Input.GetAxis("Vertical") > 0.1f)
        {
            myButton.onClick.Invoke();
        }
        else if (!usePositive && Input.GetAxis("Vertical") < -0.1f)
        {
            myButton.onClick.Invoke();
        }
	}
}
