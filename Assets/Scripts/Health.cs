using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {
	public AudioClip DamageSound;
	public int health = 100;

	// Update is called once per frame
	void Update() {
		if (transform.position.y < -100) {
			Die();
		}

		if (health <= 0) {
			Die();
		}
	}

	[PunRPC]
	void TakeDamage(int amount) {
		health -= amount;

		GetComponent<AudioSource>().clip = DamageSound;
		GetComponent<AudioSource>().Play();
	}

	void Die() {
		// Check if object killed is instantiated on network
		if (GetComponent<PhotonView>().instantiationId == 0) {
			Destroy(gameObject);
		} else {
			if (GetComponent<PhotonView>().isMine) {
				if (gameObject.tag == "Player") {
					GameManager.inGame = false;
				}

				PhotonNetwork.Destroy(gameObject);
			}
		}
	}
}
