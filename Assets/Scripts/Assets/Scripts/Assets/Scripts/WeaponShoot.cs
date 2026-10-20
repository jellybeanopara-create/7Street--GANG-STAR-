





using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    public Camera playerCamera;
    public float damage = 25f;
    public float range = 100f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (playerCamera == null)
        {
            Debug.LogWarning("Player camera is not assigned!");
            return;
        }

        RaycastHit hit;

        if (Physics.Raycast(
            playerCamera.transform.position,
            playerCamera.transform.forward,
            out hit,
            range))
        {
            Debug.Log("Hit: " + hit.collider.name);

            TargetHealth target =
                hit.collider.GetComponent<TargetHealth>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
