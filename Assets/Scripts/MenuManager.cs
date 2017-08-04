using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
	public GameObject mainMenu;
	public GameObject optionsMenu;
    public GameObject[] heroes;
    GameObject currentHero;

	void Start()
	{
        // Set the main menu model to a random hero
        GameObject randomHero = heroes[UnityEngine.Random.Range(0, heroes.Length)];
        currentHero = Instantiate(randomHero, GameObject.Find("Model").transform);

        // Update the UI
		GameObject.Find("CurrentHero").GetComponentInChildren<Text>().text = randomHero.transform.name;
		GameObject.Find("Version").GetComponentInChildren<Text>().text = "version " + GameManager.VERSION;
	}

	void Update()
	{
		// Rotate the current hero around and around
        GameObject.Find("Model").transform.rotation *= Quaternion.Euler(0, 0.15f, 0);
	}

	public void StartGame()
	{
		// Load a level (just test for now)
		SceneManager.LoadScene("Level");
	}

	public void OptionsMenu()
	{
		optionsMenu.SetActive(true);
	}

	public void MainMenu()
	{
		optionsMenu.SetActive(false);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
