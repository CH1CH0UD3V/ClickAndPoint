using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class INCEPTIONLeftWall : MonoBehaviour
{
    [SerializeField] Animator _animation;
    //[SerializeField] NavMeshSurface _LeftS;
    //[SerializeField] NavMeshSurface _GroundS;

    bool _WakeUpLeft = true;

    private void OnTriggerEnter (Collider other)
    {
        PlayerTag Player = other.GetComponentInParent<PlayerTag> ();
        if (Player != null)
        {
            _animation.SetBool ("WakeUpLeft", _WakeUpLeft);
            //_LeftS.BuildNavMesh();
            //_GroundS.BuildNavMesh();
        }
    }
}
