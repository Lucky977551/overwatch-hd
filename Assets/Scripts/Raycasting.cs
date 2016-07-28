using UnityEngine;
using System.Collections;

public class Raycasting : Photon.MonoBehaviour {
	PhotonView myPhotonView;
	
	// Update is called once per frame
	void FixedUpdate () {
		RaycastHit hit;
		Debug.DrawRay(transform.position, transform.forward * 50, Color.green);

		if (photonView.isMine) {

		}
		if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity) && Input.GetMouseButtonDown(0)) {
			Debug.Log("hit " + hit.collider.gameObject.name);
			photonView.RPC("ApplyDamage", PhotonTargets.All, 20);
        }
	}
}
