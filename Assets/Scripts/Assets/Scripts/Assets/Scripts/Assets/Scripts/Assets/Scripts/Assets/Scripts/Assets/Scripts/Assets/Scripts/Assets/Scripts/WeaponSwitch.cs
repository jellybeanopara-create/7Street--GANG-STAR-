



using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject[] weapons;

    private int currentWeaponIndex = 0;

    void Start()
    {
        if (weapons == null || weapons.Length == 0)
        {
            Debug.LogWarning("No weapons assigned!");
            return;
        }

        SelectWeapon(0);
    }

    public void NextWeapon()
    {
        if (weapons == null || weapons.Length == 0)
            return;

        int nextIndex =
            (currentWeaponIndex + 1) % weapons.Length;

        SelectWeapon(nextIndex);
    }

    public void PreviousWeapon()
    {
        if (weapons == null || weapons.Length == 0)
            return;

        int previousIndex =
            (currentWeaponIndex - 1 + weapons.Length)
            % weapons.Length;

        SelectWeapon(previousIndex);
    }

    private void SelectWeapon(int index)
    {
        currentWeaponIndex = index;

        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i] != null)
            {
                weapons[i].SetActive(i == index);
            }
        }

        Debug.Log("Selected weapon: " + index);
    }
}
