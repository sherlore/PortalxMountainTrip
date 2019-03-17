using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFoVFollow : MonoBehaviour {

    public Camera myCam;
    public Camera targetCam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(myCam.fieldOfView != targetCam.fieldOfView)
        {
            myCam.fieldOfView = targetCam.fieldOfView;
        }	
	}


}
