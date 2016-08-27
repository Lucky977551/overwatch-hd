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

		if (Input.GetButtonDown("Primary Fire")) {
			Attack(20);
		}

		Debug.Log(cooldown.ToString());
	}

	void Attack(int amount) {
		if (cooldown > 0) {
			return;
		}

		Debug.Log("Fire!");

		Ray attack = new Ray(transform.position, transform.forward);
		if (Physics.Raycast(attack, out hitInfo)) {
			Debug.Log("Hit object: " + hitInfo.collider.name);

			if (hitInfo.transform.gameObject.GetComponent<PhotonView>() != null) {
				hitInfo.transform.gameObject.GetComponent<PhotonView>().RPC("TakeDamage", PhotonTargets.AllBuffered, amount);
			}
		}

		// Begin cooldown
		cooldown = 0.5f;
	}
}
