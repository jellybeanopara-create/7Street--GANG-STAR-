



using UnityEngine;

public class WeaponReload : MonoBehaviour
{
    public int magazineSize = 30;
    public int reserveAmmo = 120;
    public float reloadTime = 2f;

    public int CurrentAmmo { get; private set; }

    private bool isReloading = false;

    void Start()
    {
        CurrentAmmo = magazineSize;
    }

    public void Reload()
    {
        if (isReloading)
            return;

        if (CurrentAmmo >= magazineSize)
            return;

        if (reserveAmmo <= 0)
            return;

        StartCoroutine(ReloadRoutine());
    }

    private System.Collections.IEnumerator ReloadRoutine()
    {
        isReloading = true;

        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        int neededAmmo = magazineSize - CurrentAmmo;
        int ammoToLoad = Mathf.Min(neededAmmo, reserveAmmo);

        CurrentAmmo += ammoToLoad;
        reserveAmmo -= ammoToLoad;

        isReloading = false;

        Debug.Log("Reload complete!");
    }

    public bool TryUseAmmo()
    {
        if (isReloading || CurrentAmmo <= 0)
            return false;

        CurrentAmmo--;
        return true;
    }
}
