using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    [SerializeField] private float mouseSensitivity;
    private float xRotation = 0f;
    private bool isMouseLookEnabled;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        isMouseLookEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMouseLookEnabled)
        {
            Look();
        }
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Rotate the camera up and down
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        // Rotate the player body left and right
        playerBody.Rotate(Vector3.up * mouseX);
    }

    public void SetMouseLookStatus(bool status)
    {
        isMouseLookEnabled = status;
    }

}
