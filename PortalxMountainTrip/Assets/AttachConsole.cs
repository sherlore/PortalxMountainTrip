using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachConsole : MonoBehaviour {

    public Transform myParent;
    public Transform myChild;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AttachChild()
    {
        myChild.parent = myParent;
        myChild.localPosition = Vector3.zero;
        myChild.localRotation = Quaternion.identity;
    }

    public void DeattachChild()
    {
        myChild.parent = null;
    }
}
