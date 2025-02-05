using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    CharacterController playerCon;
    private float gravity = 9.8f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCon = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        playerCon.Move(move * Time.deltaTime * speed);
        Gravity();
    }
    void Gravity()
    {
        playerCon.Move(Vector3.down * Time.deltaTime * gravity);
    }
}
