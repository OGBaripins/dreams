using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyReference : MonoBehaviour
{
    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public Animator animator;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
}
