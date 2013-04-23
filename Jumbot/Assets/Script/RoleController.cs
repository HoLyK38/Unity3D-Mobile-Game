using UnityEngine;
using System.Collections;

public class RoleController : MonoBehaviour {
	public float Threshold;
	public Role Role;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void GetInput(int count,Vector3 movement)
	{
		print(count);
		
		
		if(count==1)
		{
			float horizontal = movement.x;
			if(Mathf.Abs(horizontal)>Threshold)
			{
				if(horizontal>0){
					//Turn Right
					//print ("right");
					Role.TurnRight();
				}else if(horizontal<0){
					//Turn Left
					Role.TurnLeft();
				}
			}
			float vertical = movement.y;
			if(Mathf.Abs(vertical)>Threshold){
				if(vertical>0){
					//Jump Up
					//print ("up");
					Role.JumpUp(500.0f);
				}else if(vertical<0){
					//Down
					//print ("down");
					Role.TreadDown();
				}
			}
		}
	}
}
