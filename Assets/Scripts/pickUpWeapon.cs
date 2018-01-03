using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpWeapon : MonoBehaviour {

	public GameObject pickupBtn;
	public GameObject crosshair;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == "pistolPickUp")
		{
			pickupBtn.gameObject.SetActive (true);
			crosshair.gameObject.SetActive (false);
		}
	}

	void OnCollisionExit (Collision col)
	{
		if (col.gameObject.name == "pistolPickUp")
		{
			pickupBtn.gameObject.SetActive (false);
			crosshair.gameObject.SetActive (true);
		}
	}
}
