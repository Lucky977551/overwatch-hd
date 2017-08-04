using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
	public GameObject mainMenu;
	public GameObject optionsMenu;
    public GameObject[] heroes;

    GameObject curHero;
    GameObject curMenu;

	void Start()
	{
        // Set the main menu model to a random hero
        GameObject randomHero = heroes[UnityEngine.Random.Range(0, heroes.Length)];
        curHero = Instantiate(randomHero, GameObject.Find("Model").transform);

        // Update the UI
        curMenu = GameObject.FindGameObjectWithTag("Menu");

		GameObject.Find("CurrentHero").GetComponentInChildren<Text>().text = randomHero.transform.name;
		GameObject.Find("Version").GetComponentInChildren<Text>().text = "version " + GameManager.VERSION;
	}

	void Update()
	{
		// Rotate the current hero around and around
        curHero.transform.rotation *= Quaternion.Euler(0, 0.15f, 0);
	}

    public void SwitchMenu(GameObject newMenu)
    {
        curMenu.SetActive(false);
        newMenu.SetActive(true);

        curMenu = newMenu;
    }

    public void StartGame()
    {
        // Load a level (just test for now)
        SceneManager.LoadScene("Level");
    }

	public void QuitGame()
	{
		Application.Quit();
	}
}
