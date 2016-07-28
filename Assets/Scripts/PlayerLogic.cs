using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour {
	public int health = 100;
	public AudioClip quote;
	//public float deathTimer = 100.0f;
	//bool dead = false;

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
		//if (dead == true && deathTimer > 0) {
			//Destroy(gameObject);
			//deathTimer -= Time.deltaTime;
		//}
		//if (deathTimer < 1) {
			//Respawn();
		//}
	}

	//void Respawn() {
		//Destroy(gameObject);
		//GetComponent<AudioSource>().clip = quote;
		//GetComponent<AudioSource>().Play();

		// Respawn the player
		//GameObject.Find("GameManager").GetComponent<NetworkManager>().SpawnPlayer();
	//}

	void KillPlayer() {
		Destroy(gameObject);
		GetComponent<AudioSource>().clip = quote;
		GetComponent<AudioSource>().Play();

		// Respawn the player
		GameObject.Find("GameManager").GetComponent<NetworkManager>().SpawnPlayer();
		//dead = true;
		Debug.Log("You have died.");
	}
}
