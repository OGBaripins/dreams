using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Taget : MonoBehaviour, IDamagable
{

    [SerializeField] float maxHealth;
    [SerializeField] float health;

    public bool isDead;

    private EnemyReference enemyReferences;

    public void Damage(float damage)
    {
        Slider slider = transform.GetComponentInChildren<Slider>();

        health -= damage;
        slider.value = calculateHealth();
        if (health <= 0)
        {
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        enemyReferences.animator.SetBool("Dead", true);
        print("I die");
        yield return new WaitForSeconds(1.3f);
        Destroy(gameObject);
        print("I dead");
    }

    private void Awake()
    {
        enemyReferences = GetComponent<EnemyReference>();
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
