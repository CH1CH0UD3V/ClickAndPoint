using UnityEngine;

public class INCEPTIONRightWall : MonoBehaviour
{
    [SerializeField] Animator _animation;

    bool _WakeUpRight;

    private void OnTriggerEnter (Collider other)
    {
        PlayerTag Player = other.GetComponentInParent<PlayerTag> ();
        if (Player != null)
        {
            _WakeUpRight = true;
            _animation.SetBool ("WakeUpRight", _WakeUpRight);
        }
    }
}
