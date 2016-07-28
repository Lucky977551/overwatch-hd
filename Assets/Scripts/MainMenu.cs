using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
	GameObject currentHero;

	void Start() {
		currentHero = GameObject.Find("Moneky");

		GameObject.Find("CurrentHero").GetComponentInChildren<Text>().text = currentHero.transform.name;
		GameObject.Find("Version").GetComponentInChildren<Text>().text = "version " + GameManager.VERSION;
	}

	void Update() {
		// Rotate the current hero around and around
		currentHero.transform.rotation = currentHero.transform.rotation * Quaternion.Euler(0, 1, 0);
	}

	public void StartGame() {
		Debug.Log("Starting game...");

		// Load a level (just test for now)
		SceneManager.LoadScene("Level");
	}

	public void OptionsMenu() {
		Debug.Log("Switching to options menu...");
	}

	public void FrontMenu() {

	}
}
