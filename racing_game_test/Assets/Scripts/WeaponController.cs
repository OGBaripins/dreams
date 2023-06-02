using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    Animator animator;
    ParticleSystem muzzle_flash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        muzzle_flash = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("shoot");
            muzzle_flash.Play();
        }
    }
}
