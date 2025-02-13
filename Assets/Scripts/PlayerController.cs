using UnityEngine;

//-- To Do List --//
// 1. Jumping 2.5.25
// 2. Mouse Look 2.11.25 (script in another file)
// 3. Sprinting
// 4. Specific for Hotkeys?? Do I need to even do that?
// 5. Environment Scaling / Player Scaling 2.7.25
// 6. Crouching??

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;

    CharacterController characterController;
    private float gravity = -9.81f;
    private Vector3 move;
    private Vector3 velocity;

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
        Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = transform.right * moveDir.x + transform.forward * moveDir.z;

        // Apply gravity BEFORE jumping else gravity is setting your y to basically 0 which means no jump
        Gravity();
        Jump();

        // Move the character
        characterController.Move((move * moveSpeed + velocity) * Time.deltaTime);
    }

    //-- Sub Functions --//
    void Jump()
    {
        if (characterController.isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }
    }

    void Gravity()
    {
        if (!characterController.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = -0.2f;
        }
    }
}