using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Primary Fire")) {
			Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward * 50, Color.magenta);

			if (Physics.Raycast(gameObject.transform.position, Vector3.forward, Mathf.Infinity)) {
				Debug.Log("working");
			}
		}
	}
}
