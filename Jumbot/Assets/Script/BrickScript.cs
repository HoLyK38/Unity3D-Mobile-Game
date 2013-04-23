using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollision(Collision other)
	{
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
