using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Vector3 moveDirection = Vector3.zero;
    //public GameObject lobbyMenu;
    //public GameObject inGameMenu;

    float cooldown = 1f;

    float speed = 12f;
    float jumpSpeed = 8f;
    float gravity = 20f;

    public AudioClip quote;
    public AudioClip ultimate;

    void Start()
    {
        GameObject.Find("LobbyMenu").SetActive(false);
        //inGameMenu.SetActive(true);
    }

    // FixedUpdate is called consistently, regardless of framerate
    void FixedUpdate()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);

            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Gravity
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        cooldown -= Time.deltaTime;
        if (Input.GetButtonDown("Ultimate Ability") && cooldown <= 0)
        {
            moveDirection.y = jumpSpeed * 100f;
            GetComponent<AudioSource>().clip = ultimate;
            GetComponent<AudioSource>().Play();
        }
    }
}
