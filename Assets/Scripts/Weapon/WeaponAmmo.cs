using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAmmo : MonoBehaviour
{
    private Weapon weapon;

    private void Start()
    {
        weapon = GetComponent<Weapon>();
        RefillAmmo();
    }

    // Consume our ammo when we shoot
    public void ConsumeAmmo()
    {
        if (weapon.UseMagazine)
        {
            weapon.CurrentAmmo -= 1;
        }
    }

    // Returns true if we have if we have enough ammo
    public bool CanUseWeapon()
    {
        if (weapon.CurrentAmmo > 0)
        {
            return true;
        }

        return false;
    }

    // Refills our weapon with ammo
    public void RefillAmmo()
    {
        if (weapon.UseMagazine)
        {
            weapon.CurrentAmmo = weapon.MagazineSize;
        }
    }
}
