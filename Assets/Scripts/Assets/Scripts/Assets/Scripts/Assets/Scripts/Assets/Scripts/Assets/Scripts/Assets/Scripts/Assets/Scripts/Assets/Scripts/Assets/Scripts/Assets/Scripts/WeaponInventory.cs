

using UnityEngine;
using System.Collections.Generic;

public class WeaponInventory : MonoBehaviour
{
public List<string> ownedWeapons =
new List<string> { "Glock" };

public bool OwnsWeapon(string weaponName)  
{  
    return ownedWeapons.Contains(weaponName);  
}  

public void AddWeapon(string weaponName)  
{  
    if (string.IsNullOrWhiteSpace(weaponName))  
        return;  

    if (!OwnsWeapon(weaponName))  
    {  
        ownedWeapons.Add(weaponName);  
        Debug.Log("Weapon unlocked: " + weaponName);  
    }  
}  

public bool RemoveWeapon(string weaponName)  
{  
    if (weaponName == "Glock")  
    {  
        Debug.Log("The starting Glock cannot be removed.");  
        return false;  
    }  

    return ownedWeapons.Remove(weaponName);  
}

}
