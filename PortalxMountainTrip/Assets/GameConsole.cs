using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameConsole : MonoBehaviour {
    public Text myLog;
    public bool planeFound;
    public bool imageFound;
    public static GameObject console;

    public bool inTrip;
    public GameObject startTripButton;
    public GameObject arObject;
    public Transform arRoot;
    public Transform refRoot;
	
	public GameObject panelEnter;
	public GameObject panelInTrip;
	public GameObject panelHint;
	
	public GameObject[] stageGate;
	public GameObject nowGate;
	public static int gateIndex;
    public int testIndex;
	
	public Transform[] stageCenter;
    public Vector3[] stageOffset;
	public Transform environmentCenter;

    public GameObject arHint;

	// Use this for initialization
	void Start () 
	{
        arObject.SetActive(false);
        SetPlaneFound(false);
        SetImageFound(false);
        GameConsole.console = gameObject;
		
		foreach(GameObject gate in stageGate)
		{
			gate.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
        /*if(Input.GetButtonDown("Jump"))
        {
            ChooseStage(testIndex);
        }*/
	}

    public void SetPlaneFound(bool val)
    {
        planeFound = val;
        CheckReady();
        //PrintLog();

    }

    public void SetImageFound(bool val)
    {
        imageFound = val;
        CheckReady();
        PrintLog();
    }

    public void PrintLog()
    {
        Debug.Log("Plane Found: " + planeFound
                  + "\nImage Found: " + imageFound);
    }

    public void CheckReady()
    {
        if (!inTrip)
        {
            if (planeFound && imageFound)
            {
                startTripButton.SetActive(true);
            }
            else
            {
                startTripButton.SetActive(false);
            }
        }

    }

    public void StartTrip()
    {
        arRoot.position = refRoot.position;
        arRoot.rotation = refRoot.rotation;
        inTrip = true;
    }
	
	public void ChooseStage(int val)
	{
        arObject.SetActive(true);
		
		panelEnter.SetActive(false);
		panelHint.SetActive(true);
		panelInTrip.SetActive(true);
		
		if(nowGate)
			nowGate.SetActive(false);
		
		nowGate = stageGate[val];
        environmentCenter.position = stageCenter[val].position + stageOffset[val];
		
		GameConsole.gateIndex = val;
		nowGate.SetActive(true);

        arHint.SetActive(false);
	}

    public void StopTrip()
    {
        inTrip = false;
        arObject.SetActive(false);
    }
}
