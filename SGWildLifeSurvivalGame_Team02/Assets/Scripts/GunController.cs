using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public int damage;
    public float fireRate;
    public float spread;
    public float range;
    public float reload time;
    public float timeBetweenShots;
    public int magSize;
    public int bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft;
    int bulletsShot;

    bool shooting;
    bool readyToShoot;
    bool reloading;

    public Camera fpsView;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask WhatIsEnemy;

    private void Awake()
    {
        bulletsLeft = magSize;
        readyToShoot = true;
    }

    private void Update()
    {
        MyInput();
    }

    private void MyInput()
    {
        if (allowButtonHold)
        {
            shooting = MyInput().GetKey(Keycode.Mouse0);
        }
        else
        {
            shooting = MyInput().GetKeyDown(Keycode.Mouse0);
        }

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magSize && !reloading)
        {
            Reload();
        }

        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }

    }

    private void Shoot()
    {
        readyToShoot = false;

        //BulletSpread
        float x = Random.range(-spread, spread);
        float y = Random.range(-spread, spread);

        Vector 3 direction = fpsView.transform.forward + new Vector3(x, y, 0);

        //RayCast
        if (Physics.Raycast(fpsView.transform.position, direction, out rayHit, range, WhatIsEnemy))
        {
            Debug.Log(rayHit.collider.name);

            if (rayHit.collider.CompareTag("Enemy"))
            {
                rayHit.collider.GetComponent<EnemyAI>(TakeDamage(damage));
            }
        }

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", fireRate);

        if (bulletsShot > 0 && bulletsLeft > 0)
        {
            Invoke("Shoot", timeBetweenShots);
        }
        
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }

    private void Reload ()
    {
        reloading = true;
        invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magSize;
        reloading = false;
    }
}
