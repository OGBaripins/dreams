using System;
<<<<<<< HEAD
=======
using System.Collections;
using System.Collections.Generic;
>>>>>>> dd304709028f24170503e09c193c995b33610922
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
<<<<<<< HEAD
            print("Reloading");
=======
>>>>>>> dd304709028f24170503e09c193c995b33610922
            reloadInput.Invoke();
        }
    }
}
