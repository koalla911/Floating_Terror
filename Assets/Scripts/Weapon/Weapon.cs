using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float timeBtwShots = 0.5f;

    [Header("Weapon")]
    [SerializeField] private bool useMagasine = true;
    [SerializeField] private int magazineSize = 30;
    [SerializeField] private bool autoReload = true;

    [Header("Recoil")]
    [SerializeField] private bool useRecoil = true;
    [SerializeField] private int recoilForce = 5;

    
    public RobotCharacter WeaponOwner { get; set; }
    public int CurrentAmmo { get; set; }
    public WeaponAmmo WeaponAmmo { get; set; }

    public bool UseMagazine => useMagasine;
    public int MagazineSize => magazineSize;

    
    public bool CanShoot { get; set; }
    private float nextShotTime;
    private RobotController controller;


    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    
    


    private void Awake()
    {
        WeaponAmmo = GetComponent<WeaponAmmo>();
        CurrentAmmo = magazineSize;
        
    }
    protected virtual void Update() 
    {
        /*if (Input.GetMouseButton(0) && Time.time > nextFire) 
        {
            nextFire = Time.time + fireRate;
            StartShooting();

        }*/
        WeaponCanShoot();
        

    }

    public void TriggerShot() 
    {
        StartShooting();

    }

    public void StopWeapon()
    {
        if (useRecoil)
        {
            controller.ApplyRecoil(Vector2.one, 0f);
        }
    }

    
    

    private void StartShooting() 
    {
        if (useMagasine)
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

    protected virtual void RequestShot()
    {
        /*GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);*/

        if  (!CanShoot)
        {
            return;
        }
        
        if (useRecoil)
        {
            Recoil();
        }

        Debug.Log("Shooting");
        WeaponAmmo.ConsumeAmmo();
        Recoil();

        CanShoot = false;

    }

    private void Recoil()
    {
        if (WeaponOwner != null)
        {
            if (WeaponOwner.GetComponent<RobotFlip>().FacingUp)
            {
                controller.ApplyRecoil(Vector2.left, recoilForce);
            }

            else
            {
                controller.ApplyRecoil(Vector2.right, recoilForce);

            }
        }

    }

    protected virtual void WeaponCanShoot()
    {
        if (Time.time > nextShotTime)
        {
            CanShoot = true;
            nextShotTime = Time.time + timeBtwShots;
        }

    }

    public void SetOwner(RobotCharacter owner) 
    {
        WeaponOwner = owner;
        controller = WeaponOwner.GetComponent<RobotController>();

    }
    public void Reload()
    {
        if (WeaponAmmo != null)
        {
            if (useMagasine)
            {
                WeaponAmmo.RefillAmmo();
            }
        }

    }

    


    
}
