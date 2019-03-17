using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour {

    public Transform[] transforms;
    public Text myLog;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        string temp = "";

        foreach(Transform target in transforms)
        {
            temp += target.name + " with gobal at " + target.position.ToString() + "\n";
            temp += target.name + " with local at " + target.localPosition.ToString() + "\n";
        }


        myLog.text = temp;
	}
}
