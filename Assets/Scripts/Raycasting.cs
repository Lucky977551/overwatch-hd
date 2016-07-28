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

		if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity) && Input.GetMouseButtonDown(0)) {
			Debug.Log("hit " + hit.collider.gameObject.name);
			hit.transform.SendMessage("TakeDamage", 10, SendMessageOptions.DontRequireReceiver);
        }
	}
}
