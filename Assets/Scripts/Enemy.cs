using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public float health = 30f;
	AudioSource bloodSound;
	public Text countText;
	private bool isDead;

	// Use this for initialization
	void Start () {
		AudioSource[] audios = GetComponents<AudioSource> ();
		bloodSound = audios [1];
		countText = GameObject.Find("killCount").GetComponent<Text>();
		isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage(float damage)
	{
		bloodSound.Play ();

		health -= damage;
		print (health);

		if (health <= 0f)
		{
			if(!isDead)
			{
				Die ();
			}
		}
	}

	void Die ()
	{
		GetComponent<Animator> ().Play ("die");
		countText.text = (int.Parse(countText.text) + 1).ToString();
		isDead = true;
		// GetComponent<Rigidbody>().velocity = Vector3.zero;
		Destroy (gameObject, 1f);
	}
}
