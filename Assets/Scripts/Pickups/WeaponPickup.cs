using UnityEngine;

public class WeaponPickup : Pickup
{
    [SerializeField] private WeaponSO weaponSO;

    protected override void OnPickup(ActiveWeapon activeWeapon)
    {
        audioSource?.PlayOneShot(weaponClip);
        activeWeapon.SwitchWeapon(weaponSO);
    }
}

