using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Taget : MonoBehaviour, IDamagable
{

    [SerializeField] float maxHealth;
    [SerializeField] float health;

    public void Damage(float damage)
    {
        Slider slider = transform.GetComponentInChildren<Slider>();

        health -= damage;
        slider.value = calculateHealth();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Slider slider = transform.GetComponentInChildren<Slider>();
        health = maxHealth;
        slider.value = calculateHealth();
    }

    // Update is called once per frame
    void Update()
    {

    }

    float calculateHealth()
    {
        return health / maxHealth;
    }
}
