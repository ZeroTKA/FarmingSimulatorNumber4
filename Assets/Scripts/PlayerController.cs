using UnityEngine;


//-- To Do List --//
// 1. Jumping
// 2. Mouse Look
// 3. Sprinting
// 4. Specific for Hotkeys?? Do I need to even do that?


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    CharacterController characterController;
    private float gravity = 9.8f;
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
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.Move(move * Time.deltaTime * moveSpeed);
        Gravity();
    }

    //-- Sub Functions --//
    void Gravity()
    {
        characterController.Move(Vector3.down * Time.deltaTime * gravity);
    }
}
