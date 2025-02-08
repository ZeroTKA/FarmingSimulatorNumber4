using UnityEngine;

//-- To Do List --//
// 1. Jumping 2.5.25
// 2. Mouse Look
// 3. Sprinting
// 4. Specific for Hotkeys?? Do I need to even do that?
// 5. Environment Scaling / Player Scaling 2.7.25

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;
    CharacterController characterController;
    private float gravity = -9.81f;
    private Vector3 move;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        characterController = gameObject.GetComponent<CharacterController>();
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

        // Apply gravity BEFORE jumping else gravity is setting your y to basically 0 which means no jump
        Gravity();
        Jump();

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
    void Gravity()
    {
        if (!characterController.isGrounded)
        {
            move.y += gravity * Time.deltaTime;
        }
        else
        {
            move.y = -0.2f;
        }
    }

}