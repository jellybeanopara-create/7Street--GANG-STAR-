using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 4f;
    public float sprintSpeed = 7f;
    public float gravity = -20f;

    private CharacterController controller;
    private Vector3 velocity;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move =
            transform.right * x +
            transform.forward * z;

        move = Vector3.ClampMagnitude(move, 1f);

        controller.Move(
            move * walkSpeed * Time.deltaTime
        );

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(
            velocity * Time.deltaTime
        );
    }
}
