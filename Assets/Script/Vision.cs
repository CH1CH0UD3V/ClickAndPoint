using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    [SerializeField] string _mapLayer;
    PlayerTag _target;

    public PlayerTag Target { get { return _target; } }

   
    private void OnTriggerEnter (Collider other)
    {
        EnemyMovement (other);
    }

    private void OnTriggerStay (Collider other)
    {
        EnemyMovement(other);
    }


    void EnemyMovement (Collider other)
    {
        if (other.TryGetComponent<PlayerTag> (out PlayerTag Target))
        {
            var origin = transform.position;
            var direction = Target.transform.position - transform.position;
            if (Physics.Raycast(origin, direction, direction.magnitude, LayerMask.GetMask(_mapLayer)))
            {
                Debug.DrawLine (origin, origin + direction, Color.red, 1f);
            }
            else
            {
                Debug.DrawLine (origin, origin + direction, Color.green, 1f);
                _target = Target;
            }
        }
    }
    
    
    
    
    private void OnTriggerExit (Collider other)
    {

    }
}
