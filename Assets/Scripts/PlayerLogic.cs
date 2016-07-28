using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour {
	public int health = 100;

	// Update is called once per frame
	void Update() {
		GameObject.Find("Health").GetComponentInChildren<Text>().text = health.ToString();

		if (transform.position.y < -100) {
			KillPlayer();
		}

		if (health <= 0) {
			KillPlayer();
		}
	}

	[PunRPC]
	void ApplyDamage(int amount) {
		health -= amount;
	}

	void KillPlayer() {
		Destroy(gameObject);
		Debug.Log("You have died.");

		// Respawn the player
		GameObject.Find("GameManager").GetComponent<NetworkManager>().SpawnPlayer();
	}
}
