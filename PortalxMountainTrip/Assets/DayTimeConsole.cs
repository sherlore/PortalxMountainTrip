using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTimeConsole : MonoBehaviour {

	public Material blendSky;
	public Texture[] front; //+Z
	public Texture[] back;	//-Z
	public Texture[] left;	//+X
	public Texture[] right;	//-X
	public Texture[] up;	//+Y
	public Texture[] down;	//-Y
	
	public int dayTimeIndex;
	public int dayTimeIndexTarget;
	public float skyBlendPeriod;
	public float startTime;

    public Material matFront;
    public Material matBack;
    public Material matLeft;
    public Material matRight;
    public Material matUp;
    public Material matDown;

    //public Skybox mySky;
    //public Skybox mySky2;
    public Material[] skySet;
	public Light sun;
	public Color[] lightColor;
	public float[] lightIntensity;
	// public Vector3[] lightRotation;
	public Quaternion[] lightRotationQ;
	
	// public float blend
	
	// Use this for initialization
	void Start () {
		SetDayTime(dayTimeIndex);
		//SetBlendCoef(0f);
	}
	
	// Update is called once per frame
	/*void Update () {
		if(dayTimeIndex != dayTimeIndexTarget)
		{
			if(Time.time - startTime < skyBlendPeriod)
			{
				float blendCoef = (Time.time - startTime)/skyBlendPeriod;
				SetBlendCoef(Mathf.Lerp(0f, 1f, blendCoef ));
				
				int nextDayTime;
				if(dayTimeIndex != front.Length-1)
					nextDayTime = dayTimeIndex+1;
				else
					nextDayTime = 0;
				
				sun.color = Color.Lerp(lightColor[dayTimeIndex], lightColor[nextDayTime], blendCoef);
				sun.intensity = Mathf.Lerp(lightIntensity[dayTimeIndex], lightIntensity[nextDayTime], blendCoef);
				// sun.transform.eulerAngles = Vector3.Slerp(lightRotation[dayTimeIndex], lightRotation[nextDayTime], blendCoef);
				sun.transform.rotation = Quaternion.Slerp(lightRotationQ[dayTimeIndex], lightRotationQ[nextDayTime], blendCoef);
			}
			else
			{
				
				if(dayTimeIndex != front.Length-1)
					dayTimeIndex++;
				else
					dayTimeIndex = 0;
				
				// lightRotationQ[dayTimeIndex] = sun.transform.rotation; 
				SetDayTime(dayTimeIndex);
				SetBlendCoef(0f);
				startTime = Time.time;
			}
		}
	}*/
	
	
	public void FlyToDayTime(int val)
	{
        //startTime = Time.time;
        //dayTimeIndexTarget = val;
        SetDayTime(val);
	}
	
	
	public void SetDayTime(int val)
	{
		sun.color = lightColor[val];
		sun.intensity = lightIntensity[val];
		// sun.transform.eulerAngles = lightRotation[val];
		sun.transform.rotation = lightRotationQ[val];
        //mySky.material = skySet[val];
        //mySky2.material = skySet[val];
        matFront.SetTexture("_MainTex", front[val]);
        matBack.SetTexture("_MainTex", back[val]);
        matLeft.SetTexture("_MainTex", left[val]);
        matRight.SetTexture("_MainTex", right[val]);
        matUp.SetTexture("_MainTex", up[val]);
        matDown.SetTexture("_MainTex", down[val]);
		
		/*if(val != front.Length-1)
		{
			blendSky.SetTexture("_FrontTex", front[val]);
			blendSky.SetTexture("_BackTex", back[val]);
			blendSky.SetTexture("_LeftTex", left[val]);
			blendSky.SetTexture("_RightTex", right[val]);
			blendSky.SetTexture("_UpTex", up[val]);
			blendSky.SetTexture("_DownTex", down[val]);
		
			blendSky.SetTexture("_FrontTex2", front[val+1]);
			blendSky.SetTexture("_BackTex2", back[val+1]);
			blendSky.SetTexture("_LeftTex2", left[val+1]);
			blendSky.SetTexture("_RightTex2", right[val+1]);
			blendSky.SetTexture("_UpTex2", up[val+1]);
			blendSky.SetTexture("_DownTex2", down[val+1]);
		}
		else
		{
			blendSky.SetTexture("_FrontTex", front[val]);
			blendSky.SetTexture("_BackTex", back[val]);
			blendSky.SetTexture("_LeftTex", left[val]);
			blendSky.SetTexture("_RightTex", right[val]);
			blendSky.SetTexture("_UpTex", up[val]);
			blendSky.SetTexture("_DownTex", down[val]);
		
			blendSky.SetTexture("_FrontTex2", front[0]);
			blendSky.SetTexture("_BackTex2", back[0]);
			blendSky.SetTexture("_LeftTex2", left[0]);
			blendSky.SetTexture("_RightTex2", right[0]);
			blendSky.SetTexture("_UpTex2", up[0]);
			blendSky.SetTexture("_DownTex2", down[0]);
		}*/
	}
	
	public void SetBlendCoef(float val)
	{
		blendSky.SetFloat("_Blend", val);
	}
}
