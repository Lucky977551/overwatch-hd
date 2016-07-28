using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public const string VERSION = "0.2.1";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}
}
