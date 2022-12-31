using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARStageConsole : MonoBehaviour
{
    [SerializeField]
	ARRaycastManager m_RaycastManager;
	
	public enum State
	{
		Idle,
		Search,
		FoundGround
	}
	
	public State state;

	private Vector2 screenCenter;
	private List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();
	
	public bool hasFoundGround;
	public Transform planeIndicator;
	
	public UnityEvent searchGroundEvent;
	public UnityEvent notFoundGroundEvent;
	public UnityEvent foundGroundEvent;
	public UnityEvent placeStageEvent;
	public UnityEvent<string> testLogEvent;
	
	public Transform stage;
		
	void Start()
	{
		screenCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
		
		StartSearch();
	}
	
	public void StartSearch()
	{
		state = State.Search;
		
		searchGroundEvent.Invoke();
	}
	
	public void PlaceStage()
	{
		state = State.Idle;
				
		stage.position = planeIndicator.position;
		stage.rotation = planeIndicator.rotation;
		
		placeStageEvent.Invoke();
	}

	void Update()
	{
		if (state == State.Search || state == State.FoundGround)
		{
			if (m_RaycastManager.Raycast(screenCenter , m_Hits))
			{
				// Only returns true if there is at least one hit
				
				hasFoundGround = false;
				
				for(int i=0; i<m_Hits.Count; i++)
				{
					if(!hasFoundGround)
					{
						HandleRaycast(m_Hits[i]);
					}
				}
				
				if( !hasFoundGround )
				{
					//Not found any plane
					if(state == State.FoundGround)
					{
						state = State.Search;
						notFoundGroundEvent.Invoke();
					}
				}
			}
		}
	}
	
	void HandleRaycast(ARRaycastHit hit)
	{
		if (hit.trackable is ARPlane plane)
		{
			// Do something with 'plane':
			Debug.Log($"Hit a plane with alignment {plane.alignment}");
			
			testLogEvent.Invoke($"Hit a plane with alignment {plane.alignment}");
			
			if(plane.alignment == PlaneAlignment.HorizontalUp)
			{
				//Found Ground		
				hasFoundGround = true;
				
				if(state == State.Search)
				{
					state = State.FoundGround;
					foundGroundEvent.Invoke();
				}
				
				//Move Pin
				planeIndicator.position = hit.pose.position;
				planeIndicator.rotation = hit.pose.rotation;
			}
			
		}
		else
		{
			// What type of thing did we hit?
			Debug.Log($"Raycast hit a {hit.hitType}");
		}
	}

}
