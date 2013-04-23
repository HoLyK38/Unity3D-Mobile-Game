using UnityEngine;
using System.Collections;

public class DownBrickScript : MonoBehaviour {
	public float downSpeed = 10.0f;
	private bool isDown = false;
	private Transform downObj;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(isDown)
		{
			this.transform.Translate(this.transform.up * -1 *downSpeed * Time.deltaTime);
			downObj.Translate(this.transform.up * -1 *downSpeed * Time.deltaTime);
		}
	}
	void OnCollision(Collision other)
	{
	}
	void OnCollisionStay(Collision other) {
		isDown = true;
		downObj = other.transform;
	}
	void OnCollisionEnter(Collision other)
	{
		if(other.transform.position.y < this.transform.position.y) this.collider.isTrigger = true;
		if(other.transform.position.y > this.transform.position.y) this.collider.isTrigger = false;
	}
	void OnCollisionExit(Collision other)
	{
		if(other.transform.position.y < this.transform.position.y) this.collider.isTrigger = true;
		if(other.transform.position.y > this.transform.position.y) this.collider.isTrigger = false;
		
		isDown = false;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.transform.position.y < this.transform.position.y) this.collider.isTrigger = true;
		if(other.transform.position.y > this.transform.position.y) this.collider.isTrigger = false;
	}
	void OnTriggerExit(Collider other)
	{
		if(other.transform.position.y < this.transform.position.y) this.collider.isTrigger = true;
		if(other.transform.position.y > this.transform.position.y) this.collider.isTrigger = false;
	}
}
