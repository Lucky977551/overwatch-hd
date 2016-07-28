using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour {
	public int health = 100;

	// Use this for initialization
	void Start() {
	}

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

	void KillPlayer() {
		Debug.Log("You have died.");
		Destroy(gameObject);

		// Respawn the player
		GameObject.Find("GameManager").GetComponent<NetworkManager>().SpawnPlayer();
	}
}
