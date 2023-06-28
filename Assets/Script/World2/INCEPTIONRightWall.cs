using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class INCEPTIONRightWall : MonoBehaviour
{
    [SerializeField] Animator _animation;
    //[SerializeField] NavMeshSurface _RightS;
    //[SerializeField] NavMeshSurface _GroundS;

    bool _WakeUpRight = true;

    private void OnTriggerEnter (Collider other)
    {
        PlayerTag Player = other.GetComponentInParent<PlayerTag> ();
        if (Player != null)
        {
            _animation.SetBool ("WakeUpRight", _WakeUpRight);
            //_RightS.BuildNavMesh ();
            //_GroundS.BuildNavMesh ();
        }
    }
}
