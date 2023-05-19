using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GunData data;
    Animator animator;
    ParticleSystem muzzle_flash;

    [SerializeField] float timeSinceLastShot;

    void Start()
    {
        animator = GetComponent<Animator>();
        muzzle_flash = GetComponentInChildren<ParticleSystem>();

        PlayerShoot.shootInput += Shoot;
        PlayerShoot.reloadInput += StartReload;
    }

    public void StartReload()
    {
        if (!data.reloading)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        data.reloading = true;


        animator.SetTrigger("reload");
        yield return new WaitForSeconds(data.reloadTime);

        data.currentAmmo = data.magSize;
        data.reloading = false;
    }

    private bool CanShoot() => !data.reloading && timeSinceLastShot > 1f / (data.fireRate / 60f);

    public void Shoot()
    {
        if (data.currentAmmo > 0 && CanShoot())
        {

            if (Physics.Raycast(muzzle_flash.transform.position, transform.forward, out RaycastHit hitInfo, data.maxDistance))
            {
                IDamagable damagable = hitInfo.transform.GetComponent<IDamagable>();

                damagable?.Damage(data.damage);
            }
            animator.SetTrigger("shoot");
            muzzle_flash.Play();

            data.currentAmmo--;
            timeSinceLastShot = 0;

        }
    }

    void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        Debug.DrawRay(muzzle_flash.transform.position, muzzle_flash.transform.forward);
    }

}
