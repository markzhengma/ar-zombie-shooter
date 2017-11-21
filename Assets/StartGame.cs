using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.iOS;

public class StartGame : MonoBehaviour {

	public Button startBtn;
	private UnityARHitTestExample UnityARHitTestExample;
	public Image crosshair;

	// Use this for initialization
	void Start () {
		startBtn.onClick.AddListener (startNewGame);
	}
	
	void startNewGame()
	{
		UnityARHitTestExample = GetComponent<UnityARHitTestExample> ();
		Destroy (UnityARHitTestExample);
		startBtn.gameObject.SetActive (false);
		crosshair.gameObject.SetActive (true);
	}
}
