using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] Transform [] _wayPoints;
    [SerializeField] NavMeshAgent _agentEnemy;

    int _wayIndex;

    //enum enemy {WALK, SEE, PURCHASE}

    private void Awake ()
    {
        _agentEnemy = GetComponent<NavMeshAgent> ();
    }
    private void Start ()
    {
        _wayIndex = 0;
        _agentEnemy.SetDestination (_wayPoints[_wayIndex].position);
    }
    void Update()
    {
        if (_agentEnemy.remainingDistance < _agentEnemy.stoppingDistance)
        {
            _wayIndex++;

            if (_wayIndex >= _wayPoints.Length)
            {
                _wayIndex = 0;
            }
            _agentEnemy.SetDestination (_wayPoints[_wayIndex].position);
        }
    }

}
