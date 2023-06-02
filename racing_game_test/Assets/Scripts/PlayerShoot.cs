using System;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public static Action shootInput;
    public static Action reloadInput;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootInput?.Invoke();
        }

        if (Input.GetKeyDown("r"))
        {
            print("Reloading");
            reloadInput.Invoke();
        }
    }
}
