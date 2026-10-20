using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform playerBody;
    public float sensitivity = 2f;
    public float maxLookAngle = 85f;

    private float verticalRotation = 0f;

    void Update()
    {
        float mouseX =
            Input.GetAxis("Mouse X") * sensitivity;

        float mouseY =
            Input.GetAxis("Mouse Y") * sensitivity;

        verticalRotation -= mouseY;

        verticalRotation = Mathf.Clamp(
            verticalRotation,
            -maxLookAngle,
            maxLookAngle
        );

        transform.localRotation =
            Quaternion.Euler(verticalRotation, 0f, 0f);

        if (playerBody != null)
        {
            playerBody.Rotate(
                Vector3.up * mouseX
            );
        }
    }
}
