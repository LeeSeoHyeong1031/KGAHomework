using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private NavMeshAgent nav;

    private void Update()
    {
        nav.SetDestination(target.position);
    }
}
