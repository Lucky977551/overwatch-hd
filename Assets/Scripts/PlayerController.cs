﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	Vector3 moveDirection = Vector3.zero;

	float speed = 6.0F;
	float jumpSpeed = 8.0F;
	float gravity = 20.0F;

	public int health = 100;

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


		if (Input.GetButtonDown("Ultimate Ability")) {
			TakeDamage(10);
		}

		if (transform.position.y < -100) {
			KillHero();
		}

		if (health >= 0) {
			KillHero();
		}

		GameObject.Find("Health").GetComponentInChildren<Text>().text = health.ToString();
	}

	void TakeDamage(int amount) {
		health -= amount;
	}

	void KillHero() {
		Debug.Log("Died, respawning.");

		health = 100;
		transform.position = GameObject.Find("Spawnpoint").transform.position;
	}
}