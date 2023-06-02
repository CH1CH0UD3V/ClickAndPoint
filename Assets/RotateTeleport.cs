using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RotateTeleport : MonoBehaviour
{
    RotateTeleportSO _rtSO;
    [SerializeField] Rigidbody _rbPlayer;
    [SerializeField] NavMeshData navMeshData;

    private void Start ()
    {
        _rtSO = GetComponent<RotateTeleportSO> ();
    }
    private void OnTriggerEnter (Collider other)
    {
        PlayerTag Player = other.GetComponentInParent<PlayerTag> ();
        if (Player != null)
        {
            _rbPlayer.isKinematic = true;

            RaycastHit hit;

            if (Physics.Raycast (transform.position, transform.forward, out hit))
            {
                if (hit.collider.gameObject.name == "GroundVL")
                {
                    _rtSO.AntiRotate ();
                }

                if (hit.collider.gameObject.name == "GroundVR")
                {
                    _rtSO.Rotate ();
                }
            }

            _rbPlayer.isKinematic = false;
        }
    }
    public void StartBake ()
    {

    }
}
