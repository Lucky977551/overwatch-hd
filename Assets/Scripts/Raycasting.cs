using UnityEngine;
using System.Collections;

public class Raycasting : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		RaycastHit hit;
		Debug.DrawRay(transform.position, transform.forward * 50, Color.green);
		if (Physics.Raycast(transform.position, Vector3.forward, out hit, 8) && Input.GetMouseButtonDown(1)) {
			Debug.Log("hit.collider.gameObject.name");
        }
	}
}
