using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSwitch : MonoBehaviour {

    public string inputName;

    public Button[] btnSet;
    public bool axisDirty;
    public int index;
    public bool autoInvoke;

	// Use this for initialization
	void Start () {
        btnSet[index].interactable = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown(inputName))
        {
            btnSet[index].onClick.Invoke();
        }

        if (!axisDirty && Input.GetAxis("Horizontal") > 0.1f)
        {
            axisDirty = true;
            btnSet[index].interactable = false;
            index = index < btnSet.Length - 1 ? index + 1 : 0;
            btnSet[index].interactable = true;

            if (autoInvoke)
            {
                btnSet[index].onClick.Invoke();
            }
        }
        else if (!axisDirty && Input.GetAxis("Horizontal") < -0.1f)
        {
            axisDirty = true;
            btnSet[index].interactable = false;
            index = index > 0 ? index - 1 : btnSet.Length - 1;
            btnSet[index].interactable = true;

            if (autoInvoke)
            {
                btnSet[index].onClick.Invoke();
            }
        }
        else if (Input.GetAxis("Horizontal") == 0f)
        {
            axisDirty = false;
        }
	}
}
