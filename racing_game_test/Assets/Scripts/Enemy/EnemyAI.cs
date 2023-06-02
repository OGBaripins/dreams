using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    private Transform target;
    private EnemyReference enemyReferences;

    private EnemyReference targetRef;

    private CapsuleCollider coll;

    private SphereCollider trigger;

    private float distance;

    public static Action attackInput;

    private bool hasEntered = false;


    private void Awake()
    {
        enemyReferences = GetComponent<EnemyReference>();
        coll = GetComponent<CapsuleCollider>();
        trigger = GetComponent<SphereCollider>();
        target = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }

    void Start()
    {
        distance = enemyReferences.navMeshAgent.stoppingDistance;
    }

    void Update()
    {
        if (target != null && hasEntered)
        {
            bool range = Vector3.Distance(transform.position, target.position) <= distance;
            if (range)
            {
                lookAtTarget();
                StartCoroutine(Attack());
            }
            else
            {
                updatePath();
            }

            enemyReferences.animator.SetFloat("MoveSpeed", enemyReferences.navMeshAgent.desiredVelocity.sqrMagnitude);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Why hit me?");
            hasEntered = true;
        }

    }

    private IEnumerator Attack()
    {
        if (!enemyReferences.animator.GetBool("Attack"))
        {
            enemyReferences.animator.SetBool("Attack", true);
            print("I Attack");
            yield return new WaitForSeconds(1.3f);
            print("I attacked");
            attackInput?.Invoke();
        }

    }

    private void lookAtTarget()
    {
        Vector3 lookPos = target.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
    }

    private void updatePath()
    {
        enemyReferences.navMeshAgent.SetDestination(target.position);
    }
}
