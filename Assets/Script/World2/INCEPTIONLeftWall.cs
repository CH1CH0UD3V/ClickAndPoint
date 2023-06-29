using UnityEngine;

public class INCEPTIONLeftWall : MonoBehaviour
{
    [SerializeField] Animator _animation;

    bool _WakeUpLeft;

    private void OnTriggerEnter (Collider other)
    {
        PlayerTag Player = other.GetComponentInParent<PlayerTag> ();
        if (Player != null)
        {
            _WakeUpLeft = true;
            _animation.SetBool ("WakeUpLeft", _WakeUpLeft);
        }
    }
}
