using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusB : MonoBehaviour {

    public Renderer bonusRenderer;
    public Material bonusMaterial;
    public bool isEnter;
    public float beginEnter;
    public float stayThreshold;
    public InterdimensionalTransport player;

	// Use this for initialization
	void Start () {
        bonusMaterial = bonusRenderer.material;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(isEnter)
        {
            if (bonusMaterial)
                bonusMaterial.SetFloat("_Progress", Mathf.Lerp(0f, 1f, (Time.time-beginEnter-stayThreshold)/5f) );
        }	
	}

	private void OnTriggerEnter(Collider other)
	{
        Debug.Log("OnTriggerEnter");

        if (other.tag != "Player" || player.inReality) return;

        isEnter = true;
        beginEnter = Time.time;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");

        if (other.tag != "Player" || player.inReality) return;

        isEnter = false;
        if (bonusMaterial)
            bonusMaterial.SetFloat("_Progress", 0f);
    }

	/*private void OnEnable()
    {
        isEnter = false;
        bonusMaterial.SetFloat("_Progress", 0f);
	}*/

	public void ResetProgress()
    {
        isEnter = false;
        if(bonusMaterial)
            bonusMaterial.SetFloat("_Progress", 0f);
	}
}
