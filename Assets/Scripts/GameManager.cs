using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public const string VERSION = "0.2.3";

    public static bool isPaused = false;
    public static bool inGame = false;

    public GameObject pauseMenu;
    public GameObject cameraControl;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.GetActive())
            {
                isPaused = false;
                Cursor.lockState = CursorLockMode.Locked;

                if (inGame)
                {
                    Cursor.visible = false;
                }
            }
            else
            {
                isPaused = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        if (isPaused)
        {
            pauseMenu.SetActive(true);

        }
        else
        {
            pauseMenu.SetActive(false);
        }
    }

    public void MainMenu()
    {
        gameObject.GetComponent<NetworkManager>().LeaveRoom();
        SceneManager.LoadScene("MainMenu");
    }
}
