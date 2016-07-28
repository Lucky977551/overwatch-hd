using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	Vector3 moveDirection = Vector3.zero;

	float speed = 6.0F;
	float jumpSpeed = 8.0F;
	float gravity = 20.0F;

	int health = 100;

	bool ultimateReady = false;

	// Update is called once per frame
	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);

			moveDirection *= speed;

			if (Input.GetButton("Jump")) {
				moveDirection.y = jumpSpeed;
			}
		}

		// Gravity
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

		if (transform.position.y < -100) {
			KillHero();
		}

		if (Input.GetButtonDown("Ultimate Ability")) {
			KillHero();
		}

		GameObject.Find("Health").GetComponentInChildren<Text>().text = health.ToString();
	}

	void KillHero() {
		Debug.Log("Died, respawning.");

		health = 100;
		transform.position = GameObject.Find("Spawnpoint").transform.position;
	}
}
