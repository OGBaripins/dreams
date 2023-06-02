using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{

    [SerializeField] float playerMaxHealth;
    [SerializeField] float playerHealth;
    [SerializeField] Slider slider;
    public static Action DeathTrigger;



    void Start()
    {
        EnemyAI.attackInput += Hit;
        playerHealth = playerMaxHealth;
        slider.value = calculateHealth();
    }

    void Update()
    {

    }

    private void Hit()
    {
        playerHealth -= 20;
        slider.value = calculateHealth();
        if (playerHealth <= 0)
        {
            DeathTrigger.Invoke();
            print("  Y O U  A R E  D E A D  ! ! !   ");
        }
    }

    float calculateHealth()
    {
        return playerHealth / playerMaxHealth;
    }
}
