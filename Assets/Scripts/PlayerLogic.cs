using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour {
	public int health = 100;

	float deathTimer = 100F;
	bool dead = false;

	// Update is called once per frame
	void Update() {
		GameObject.Find("Health").GetComponentInChildren<Text>().text = health.ToString();

		if (transform.position.y < -100) {
			KillPlayer();
		}

		if (health <= 0) {
			KillPlayer();
		}

		if (dead == true && deathTimer > 0) {
			deathTimer -= Time.deltaTime;
		}
		if (deathTimer <= 0) {
			GameObject.Find("GameManager").GetComponent<NetworkManager>().SpawnPlayer();
		}
	}

	[PunRPC]
	void ApplyDamage(int amount) {
		health -= amount;
	}

	void KillPlayer() {
		Destroy(gameObject);
		dead = true;

		Debug.Log("You have died.");
	}
}
