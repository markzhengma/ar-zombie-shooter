using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponPickUp : MonoBehaviour {

	public Button pickUpBtn;
	public GameObject weapon1;
	public Text ammo1Text;
	public Text ammo2Text;
	private GameObject[] pistolPickUp;

	// Use this for initialization
	void Start () {
		pickUpBtn.onClick.AddListener (weapon1True);
		pistolPickUp = GameObject.FindGameObjectsWithTag("pistolPickUp");
	}
	
	// Update is called once per frame
	void weapon1True () 
	{
		weapon1.gameObject.SetActive (true);
		shootEnemy shootEnemy = weapon1.GetComponent<shootEnemy> ();

		shootEnemy.ammo1 = 20;
		shootEnemy.ammo2 = 100;

		string ammo1String = (shootEnemy.ammo1).ToString();
		ammo1Text.text = ammo1String;

		string ammo2String = (shootEnemy.ammo2).ToString();
		ammo2Text.text = "/" + ammo2String;

		shootEnemy.ammoIsEmpty = false;
		shootEnemy.reloadCheck = true;
		
		for(var i = 0; i < pistolPickUp.Length; i++)
		{
			pistolPickUp[i].SetActive(false);
		}
	}
}
