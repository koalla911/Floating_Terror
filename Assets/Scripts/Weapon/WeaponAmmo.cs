using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponAmmo : MonoBehaviour
{
    private Weapon weapon;

    private void Start() 
    {
        weapon = GetComponent<Weapon>();
        RefillAmmo();

    }

    public void ConsumeAmmo() 
    {
        if (weapon.UseMagazine) 
        {
            weapon.CurrentAmmo -= 1;

        }

    }

    public bool CanUseWeapon() 
    {
        if (weapon.CurrentAmmo > 0) 
        {
            return true;

        }
        return false;

    }

    public void RefillAmmo() 
    {
        weapon.CurrentAmmo = weapon.MagazineSize;

    }
}
