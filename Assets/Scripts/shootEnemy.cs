﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shootEnemy : MonoBehaviour {

	public Button shootBtn;
	public Camera fpsCam;
	public float damage = 10f;
	public GameObject bloodEffect;
	public GameObject shootingEffect;
	public int forceAdd = 300;
	AudioSource shootSound;
	AudioSource reloadSound;
	public Text ammo1Text;
	public Text ammo2Text;
	public int ammo1;
	public int ammo2;
	private bool ammoIsEmpty;
	public ParticleSystem muzzleFlash;
	public GameObject pistolGO;
	private bool reloadCheck;

	// Use this for initialization
	void Start () {
		shootBtn.onClick.AddListener(onShoot);

		AudioSource[] audios = GetComponents<AudioSource> ();
		shootSound = audios [0];
		reloadSound = audios [1];

		ammo1 = 20;
		ammo2 = 100;

		reloadCheck = true;
	}

	IEnumerator waitForReload ()
	{
		yield return new WaitForSeconds (3f);
		reloadCheck = true;
	}
	
	void onShoot ()
	{

		if (!ammoIsEmpty && reloadCheck)
		{
			if (ammo1 == 1)
			{
				ammo1 = 21;
				pistolGO.GetComponent<Animator> ().SetTrigger ("reload");
				reloadCheck = false;
				StartCoroutine (waitForReload ());
				reloadSound.Play ();
			}

			ammo1 -= 1;
			string ammo1String = (ammo1).ToString();
			ammo1Text.text = ammo1String;

			ammo2 -= 1;
			string ammo2String = (ammo2).ToString();
			ammo2Text.text = "/" + ammo2String;

			if (ammo2 == 0)
			{
				ammoIsEmpty = true;
				ammo1 = 0;
				string ammo1String2 = (ammo1).ToString();
				ammo1Text.text = ammo1String2;
			}

			shootSound.Play ();
			
			RaycastHit hit;
			if (Physics.Raycast (fpsCam.transform.position, fpsCam.transform.forward, out hit))
			{
				Enemy target = hit.transform.GetComponent<Enemy> ();

				if (target != null)
				{
					target.TakeDamage (damage);

					GameObject bloodGO = Instantiate (bloodEffect, hit.point, Quaternion.LookRotation (hit.normal));
					Destroy (bloodGO, 0.2f);
				}
				else
				{
					GameObject shootingGO = Instantiate (shootingEffect, hit.point, Quaternion.LookRotation (hit.normal));
					Destroy (shootingGO, 0.2f);
				}

				if (hit.rigidbody != null)
				{
					hit.rigidbody.AddForce (-hit.normal * forceAdd);
				}
			}

			muzzleFlash.Play ();

			pistolGO.GetComponent<Animator> ().Play("Fire");
		}
	}
}
