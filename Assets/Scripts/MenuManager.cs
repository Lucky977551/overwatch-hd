using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
	public GameObject mainMenu;
	public GameObject optionsMenu;
	GameObject currentHero;

	void Start() {
		currentHero = GameObject.Find("Moneky");

		GameObject.Find("CurrentHero").GetComponentInChildren<Text>().text = currentHero.transform.name;
		GameObject.Find("Version").GetComponentInChildren<Text>().text = "version " + GameManager.VERSION;
	}

	void Update() {
		// Rotate the current hero around and around
		currentHero.transform.rotation = currentHero.transform.rotation * Quaternion.Euler(0, 0.2f, 0);


	}

	public void StartGame() {
		Debug.Log("Starting game...");

		// Load a level (just test for now)
		SceneManager.LoadScene("Level");
	}

	public void OptionsMenu() {
		optionsMenu.SetActive(true);
	}

	public void MainMenu() {
		optionsMenu.SetActive(false);
	}
}
