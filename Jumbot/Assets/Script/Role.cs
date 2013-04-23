using UnityEngine;
using System.Collections;

public class Role : MonoBehaviour {
	private float m_EulerY; 
	private bool  m_Turning;
	private float m_Direction;
	
	public  bool  m_InAir;
	public	int   m_ExtraJump;
	
	// Use this for initialization
	void Start () {
		Quaternion q = transform.rotation;
		m_EulerY = q.eulerAngles.y;
		m_Direction = 	-1;
		m_Turning = false;
		m_ExtraJump = 0; 
		m_InAir = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(m_Turning)
		{
			m_EulerY += 180.0f * m_Direction * Time.deltaTime;
			
			if(m_EulerY < 90.0f)
			{
				m_Turning = false;
				gameObject.rigidbody.freezeRotation = true;
				m_EulerY = 90.0f;
			}else if(m_EulerY > 270.0f)
			{
				m_Turning = false;
				gameObject.rigidbody.freezeRotation = true;
				m_EulerY = 270.0f;
			}
			
			Quaternion q = new Quaternion();
			q.eulerAngles = new Vector3(0.0f,m_EulerY,0.0f);
			transform.rotation = q;
		}
		
		Vector3 temp = gameObject.rigidbody.velocity;
		gameObject.rigidbody.velocity = new Vector3(transform.forward.x,temp.y,0.0f);
		
		
	}
	
	public bool CanJump()
	{
			return !m_InAir || m_ExtraJump != 0;
	}
	
	public void JumpUp(float fouce)
	{
		m_InAir = true;
		gameObject.rigidbody.AddForce(new Vector3(0.0f,fouce,0.0f));
	}
	
	public void TreadDown(){
		gameObject.rigidbody.AddForce(new Vector3(0.0f,-200.0f,0.0f));
	}
	
	public void TurnLeft()
	{
		m_Turning = true;
		m_Direction = 1;
		gameObject.rigidbody.freezeRotation = false;
	}
	
	public void TurnRight()
	{
		m_Turning = true;
		m_Direction = -1;
		gameObject.rigidbody.freezeRotation = false;
	}
}

