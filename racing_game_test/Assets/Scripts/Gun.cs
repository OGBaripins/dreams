using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.UI;
=======
>>>>>>> dd304709028f24170503e09c193c995b33610922

public class Gun : MonoBehaviour
{
    [SerializeField] GunData data;
    Animator animator;
    ParticleSystem muzzle_flash;

<<<<<<< HEAD
    [SerializeField] TMPro.TMP_Text ammoText;

=======
>>>>>>> dd304709028f24170503e09c193c995b33610922
    [SerializeField] float timeSinceLastShot;

    void Start()
    {
        animator = GetComponent<Animator>();
        muzzle_flash = GetComponentInChildren<ParticleSystem>();

        PlayerShoot.shootInput += Shoot;
        PlayerShoot.reloadInput += StartReload;
<<<<<<< HEAD
        ammoText.text = $"{data.currentAmmo}/{data.magSize}";
=======
>>>>>>> dd304709028f24170503e09c193c995b33610922
    }

    public void StartReload()
    {
<<<<<<< HEAD
        print(data.reloading);
=======
>>>>>>> dd304709028f24170503e09c193c995b33610922
        if (!data.reloading)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        data.reloading = true;
<<<<<<< HEAD
=======


>>>>>>> dd304709028f24170503e09c193c995b33610922
        animator.SetTrigger("reload");
        yield return new WaitForSeconds(data.reloadTime);

        data.currentAmmo = data.magSize;
        data.reloading = false;
<<<<<<< HEAD
        ammoText.text = $"{data.currentAmmo}/{data.magSize}";
=======
>>>>>>> dd304709028f24170503e09c193c995b33610922
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
<<<<<<< HEAD
            data.currentAmmo--;
            ammoText.text = $"{data.currentAmmo}/{data.magSize}";
=======

            data.currentAmmo--;
>>>>>>> dd304709028f24170503e09c193c995b33610922
            timeSinceLastShot = 0;

        }
    }

    void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        Debug.DrawRay(muzzle_flash.transform.position, muzzle_flash.transform.forward);
    }

}
