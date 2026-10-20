


using UnityEngine;
using UnityEngine.EventSystems;

public class MobileCameraLook : MonoBehaviour,
    IDragHandler
{
    public Transform playerBody;
    public float sensitivity = 0.15f;
    public float maxLookAngle = 85f;

    private float verticalRotation = 0f;

    public void OnDrag(PointerEventData eventData)
    {
        float mouseX =
            eventData.delta.x * sensitivity;

        float mouseY =
            eventData.delta.y * sensitivity;

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
