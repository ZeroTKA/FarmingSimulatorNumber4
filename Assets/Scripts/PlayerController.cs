using UnityEngine;

//-- To Do List --//
// 1. Jumping
// 2. Mouse Look
// 3. Sprinting
// 4. Specific for Hotkeys?? Do I need to even do that?

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;
    CharacterController characterController;
    private float gravity = -9.8f;
    private Vector3 move;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    //-- Main Functions --//
    void PlayerMovement()
    {
        move = new Vector3(Input.GetAxis("Horizontal"), move.y, Input.GetAxis("Vertical"));

        Jump();

        // Apply gravity
        move.y += gravity * Time.deltaTime;

        // Move the character
        characterController.Move(move * Time.deltaTime * moveSpeed);
    }

    //-- Sub Functions --//
    void Jump()
    {
        if (characterController.isGrounded && Input.GetButtonDown("Jump"))
        {
            move.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }
    }
}