using System.Collections;
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

	// Use this for initialization
	void Start () {
		shootBtn.onClick.AddListener(onShoot);

		AudioSource[] audios = GetComponents<AudioSource> ();
		shootSound = audios [0];
		reloadSound = audios [1];
	}
	
	void onShoot ()
	{

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
	}
}
