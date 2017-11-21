using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnController : MonoBehaviour {

	public GameObject zombie;
	public Button startBtn;

	// Use this for initialization
	void Start () {
		startBtn.onClick.AddListener (startInvoke);
	}
	
	void startInvoke() {
		InvokeRepeating ("spawn", 0f, 5f);
	}

	void spawn(){
		Vector3 position = new Vector3 (Random.Range (-10f, 10f), 3, Random.Range (-10f, 10f));
		Instantiate (zombie, position, Quaternion.Euler(0,0,0));
	}
}
