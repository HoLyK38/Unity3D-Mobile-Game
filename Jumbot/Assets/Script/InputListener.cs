using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//***********************//
// Process Inputs		 //	
//***********************//

public class InputListener : MonoBehaviour {
	public GUIController 	GUIController;
	public RoleController 	RoleController;
	
	private Dictionary<int,Vector3> m_InputMap;
	private int 	m_InputCount;
	private Vector3 m_Delta;//the distance of the input position from begin to finish
	
	// Use this for initialization
	void Start () {
		m_InputMap = new Dictionary<int,Vector3>();
		m_InputCount = 0;
		m_Delta = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.multiTouchEnabled)
		{
			foreach (Touch touch in Input.touches) {
				switch (touch.phase)
				{
				case TouchPhase.Began:
					NewInput(touch.fingerId,touch.position);
					break;
				case TouchPhase.Ended:
					EndInput(touch.fingerId,touch.position);
					break;
				case TouchPhase.Canceled:
					CancelInput(touch.fingerId);
					break;
				}   	
			}
		}else//testing for computer
		{
			if(Input.GetMouseButtonDown(0))
			{
				NewInput(0,Input.mousePosition);
			}else if(Input.GetMouseButtonUp(0))
			{
				EndInput(0,Input.mousePosition);
			}
			
			
			if(Input.GetMouseButtonDown(1))
			{
				NewInput(1,Input.mousePosition);
			}else if(Input.GetMouseButtonUp(1))
			{
				EndInput(1,Input.mousePosition);
			}
			
			
			if(Input.GetMouseButtonDown(2))
			{
				NewInput(2,Input.mousePosition);
			}else if(Input.GetMouseButtonUp(2))
			{
				EndInput(2,Input.mousePosition);
			}

		}
		
		if(m_InputCount!=0 && m_InputMap.Count==0)
		{
			//Processing
			
			
			m_InputCount = 0;
			m_Delta = Vector3.zero;
		}
	}
	
	void NewInput(int index,Vector3 posn)
	{
		if(!m_InputMap.ContainsKey(index))
		{
			m_InputMap.Add(index,posn);
			m_InputCount++;	
		}	
	}
	
	void EndInput(int index, Vector3 posn)
	{
		print ("end");
		if(m_InputMap.ContainsKey(index))
		{
			Vector3 delta = posn - m_InputMap[index];
			m_InputMap.Remove(index);
			//Choose the longest movement
			if(delta.magnitude > m_Delta.magnitude){
				RoleController.GetInput(m_InputCount,delta);
			}
		}
	}
	
	void CancelInput(int index)
	{
		if(m_InputMap.ContainsKey(index))
		{
			
		}
	}

}