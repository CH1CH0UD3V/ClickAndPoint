using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FOLLOWER : MonoBehaviour
{
    [SerializeField] Transform _target;
    NavMeshAgent _agentFollower;
    
    void Start()
    {
        _agentFollower = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        _agentFollower.SetDestination (_target.position);
    }
}
