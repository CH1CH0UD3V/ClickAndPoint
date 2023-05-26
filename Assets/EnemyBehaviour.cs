using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] Transform [] _wayPoints;
    [SerializeField] NavMeshAgent _agentEnemy;

    int _wayCount = 0;

    enum enemy {WALK, SEE, PURCHASE}

    //void Update()
    //{
    //    switch (enemy)
    //    {
    //        case enemy.WALK:
    //            break;
    //        case enemy.SEE:
    //            break;
    //        case enemy.PURCHASE:
    //            break;
    //        default:
    //            break;
    //    }
        //for (int i = 0; i < _wayPoints.Length; i++)
        //{
        //    int wayPoint = _wayPoints[i];
        //}
    //}
}
