using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	public float scale;
	public Transform mainCamera;
	public float speed = 10;
	public float posError = 0.2f;
	/*public float jumpHeight = 7;// If character jump height higer than this value, camera move
	public float moveHeight = 5;*/
	
	
	private bool isMoving = false;
	private Vector3 moveUnit;
	private Vector3 moveDestination;
	// Use this for initialization
	void Start () {
		mainCamera = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(!isMoving)
		{
			/*Vector3 distance = mainCharacter.position - mainCamera.position;
			if( distance.y > jumpHeight )
			{
				movingDestination = mainCamera;
				movingDestination += moveHeight;
			}*/
		}
		else
		{
			StartMoving();
		}
	}
	void OnGUI ()
	{
		if(GUI.Button(new Rect(20,40,80,20), "123"))
		{
			MoveTo(new Vector3(10,70));
		}
	}
	void MoveTo(Vector3 pos)
	{
		isMoving = true;
		moveDestination = pos;
		moveUnit = (pos - mainCamera.position);
		moveUnit.z = 0;
		moveUnit.Normalize();
		print(moveUnit);
	}
	
	void StartMoving()
	{
		if( mainCamera.position.x > (moveDestination.x - posError) && mainCamera.position.x < (moveDestination.x + posError) 
			&& mainCamera.position.y > (moveDestination.y - posError) && mainCamera.position.y < (moveDestination.y + posError) )
		{
			isMoving = false;
		}
		else
		{
			mainCamera.Translate(moveUnit*Time.deltaTime*speed);
			
		}
	}
}
