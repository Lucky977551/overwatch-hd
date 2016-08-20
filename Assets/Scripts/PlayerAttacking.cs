using UnityEngine;
using System.Collections;

public class PlayerAttacking : MonoBehaviour {
	RaycastHit hitInfo;

	float cooldown = 0;

	// Update is called once per frame
	void Update() {
		if (cooldown > 0) {
			cooldown -= Time.deltaTime;
		}

		if (Input.GetButton("Primary Fire")) {
			Attack();
		}
	}

	void Attack() {
		// Ignore attack if cooldown is active
		if (cooldown > 0) {
			return;
		}

		Debug.Log("Fire!");

		Ray attack = new Ray(transform.position, transform.forward);
		if (Physics.Raycast(attack, out hitInfo)) {
			Debug.Log("Hit object: " + hitInfo.collider.name);

			hitInfo.transform.gameObject.GetComponent<PhotonView>().RPC("ApplyDamage", PhotonTargets.All, 20);
		}

		// Begin cooldown
		cooldown = 0.5f;
	}
}
