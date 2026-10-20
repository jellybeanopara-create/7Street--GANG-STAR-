


using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VehicleController : MonoBehaviour
{
    public float acceleration = 1500f;
    public float steeringSpeed = 80f;
    public float maxSpeed = 25f;
    public float brakeStrength = 3000f;

    private Rigidbody rb;

    private float throttleInput;
    private float steeringInput;
    private bool braking;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0f, -0.5f, 0f);
    }

    void FixedUpdate()
    {
        if (throttleInput > 0f &&
            rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(
                transform.forward *
                throttleInput *
                acceleration *
                Time.fixedDeltaTime,
                ForceMode.Force
            );
        }

        if (braking)
        {
            rb.AddForce(
                -rb.velocity.normalized * brakeStrength *
                Time.fixedDeltaTime,
                ForceMode.Force
            );
        }

        if (rb.velocity.magnitude > 0.5f)
        {
            float turn =
                steeringInput * steeringSpeed *
                Time.fixedDeltaTime;

            rb.MoveRotation(
                rb.rotation *
                Quaternion.Euler(0f, turn, 0f)
            );
        }
    }

    public void SetThrottle(float value)
    {
        throttleInput = Mathf.Clamp(value, -1f, 1f);
    }

    public void SetSteering(float value)
    {
        steeringInput = Mathf.Clamp(value, -1f, 1f);
    }

    public void SetBraking(bool value)
    {
        braking = value;
    }
}
