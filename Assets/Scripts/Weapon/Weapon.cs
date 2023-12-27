using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float timeBtwShots = 0.5f;

    [Header("Weapon")]
    [SerializeField] private bool useMagazine = true;
    [SerializeField] private int magazineSize = 30;
    [SerializeField] private bool autoReload = true;

    [Header("Recoil")]
    [SerializeField] private bool useRecoil = true;
    [SerializeField] private int recoilForce = 30;

    // Reference of the Character that controls this Weapon
    public Character WeaponOwner { get; set; }

    // Current Ammo we have
    public int CurrentAmmo { get; set; }

    // Reference to our WeaponAmmo
    public WeaponAmmo WeaponAmmo { get; set; }

    // Returns if this weapon use magazine
    public bool UseMagazine => useMagazine;

    // Returns the size of our Magazine
    public int MagazineSize => magazineSize;

    // Returns if we can shoot now
    public bool CanShoot { get; set; }

    // Internal
    private float nextShotTime;
    private CharacterController controller; // Because we need to know the character is facing which side for RECOIL

    private void Awake()
    {
        WeaponAmmo = GetComponent<WeaponAmmo>();
        CurrentAmmo = magazineSize;
    }

    protected virtual void Update()
    {
        WeaponCanShoot();
        RotateWeapon();
    }

    public void TriggerShot()
    {
        StartShooting();
    }

    // Makes our Weapon stop working
    public void StopWeapon()
    {
        if (useRecoil)
        {
            controller.ApplyRecoil(Vector2.one, 0f);
        }
    }

    // Activates our weapon in order to shoot
    private void StartShooting()
    {
        if (useMagazine)
        {
            if (WeaponAmmo != null)
            {
                if (WeaponAmmo.CanUseWeapon())
                {
                    RequestShot();
                }
                else
                {
                    if (autoReload)
                    {
                        Reload();
                    }
                }
            }
        }
        else
        {
            RequestShot();
        }
    }

    // Makes our weapon start shooting
    protected virtual void RequestShot()
    {
        if (!CanShoot)
        {
            return;
        }

        if (useRecoil)
        {
            Recoil();
        }

        WeaponAmmo.ConsumeAmmo();

        //CanShoot = false;  //Remove this line
    }

    // Apply a force to our movement when we shoot
    private void Recoil()
    {
        if (WeaponOwner != null)
        {
            if (WeaponOwner.GetComponent<CharacterFlip>().FacingRight)
            {
                controller.ApplyRecoil(Vector2.left, recoilForce);
            }
            else
            {
                controller.ApplyRecoil(Vector2.right, recoilForce);
            }
        }
    }

    // Controls the next time we can shoot
    protected virtual void WeaponCanShoot()
    {
        if (Time.time > nextShotTime)  //Actual time in the game GREATER THAN fire rate
        {
            CanShoot = true;  //Here we have set CanShoot is TRUE, that¡¯s why we remove a command line at RequestShot()
            nextShotTime = Time.time + timeBtwShots;
        }
    }

    // Reference the owner of this Weapon
    public void SetOwner(Character owner)
    {
        WeaponOwner = owner;
        controller = WeaponOwner.GetComponent<CharacterController>();
    }

    public void Reload()
    {
        if (WeaponAmmo != null)
        {
            if (useMagazine)
            {
                WeaponAmmo.RefillAmmo();
            }
        }
    }

    protected virtual void RotateWeapon()
    {
        if (WeaponOwner.GetComponent<CharacterFlip>().FacingRight)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
