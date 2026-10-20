using UnityEngine;
using UnityEngine.EventSystems;

public class MobileShootButton : MonoBehaviour,
    IPointerDownHandler
{
    public WeaponShoot weapon;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (weapon != null)
        {
            weapon.ShootFromMobile();
        }
        else
        {
            Debug.LogWarning(
                "MobileShootButton: Weapon is not assigned."
            );
        }
    }
}
