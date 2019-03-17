using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosFollow : MonoBehaviour {

    public Transform target;
    public Vector3 targetPos;
    public Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - target.position;
        targetPos = transform.position;
	}
	
	// Update is called once per frame
    void Update () {
        offset = transform.position - target.position;
        /*if(targetPos != target.position)
        {
            transform.position = target.position + offset;
            targetPos = target.position;
        }*/
	}
}
