using System.Collections;
using System.Collections.Generic;
using Vuforia;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MRConsole : MonoBehaviour {

	public bool useSetting;

	// Use this for initialization
	void Start () 
	{
		if(useSetting)
		{
			Invoke ("XRModeInit", 5);
		}
	}
	
	// Update is called once per frame
	void XRModeInit () 
	{

		string XRMode = PlayerPrefs.GetString("XRSetting");

		if(XRMode == "HANDHELD_AR")
		{
			MixedRealityController.Instance.SetMode(MixedRealityController.Mode.HANDHELD_AR);
		}
		else if(XRMode == "VIEWER_AR")
		{
			MixedRealityController.Instance.SetMode(MixedRealityController.Mode.VIEWER_VR);
		}
	}
	
	public void SetXRMode(string mode)
	{
		PlayerPrefs.SetString("XRSetting", mode);
    }

    public void SetXRMode(bool val)
    {
        if (val)
        {
            MixedRealityController.Instance.SetMode(MixedRealityController.Mode.HANDHELD_AR);

            SceneManager.LoadScene("main");
        }
        else
        {
            MixedRealityController.Instance.SetMode(MixedRealityController.Mode.VIEWER_VR);
            SceneManager.LoadScene("mainMR");
        }
    }
	
	public void LoadScene(string sce)
	{
        SceneManager.LoadScene(sce);
	}
	
}
