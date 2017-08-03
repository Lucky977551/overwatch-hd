using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Vector3 moveDirection = Vector3.zero;
    public GameObject lobbyMenu;
    public GameObject inGameMenu;

    float cooldown = 1f;

    float speed = 12.0F;
    float jumpSpeed = 8.0F;
    float gravity = 20.0F;

    public AudioClip quote;
    public AudioClip ultimate;

    void Start()
    {
        GameObject.Find("LobbyMenu").SetActive(false);
        inGameMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
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
        if (Input.GetButtonDown("Ultimate Ability") && cooldown >= 0)
        {
			
        }
    }

    void DoUltimate()
    {

    }
}
