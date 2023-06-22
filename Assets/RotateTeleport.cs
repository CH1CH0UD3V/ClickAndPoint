using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class RotateTeleport : MonoBehaviour
{
    #region Champ
    //[SerializeField] RotateTeleportSO _rtSO;
    [Space (15)]
    [SerializeField] Rigidbody _rbPlayer;
    [Space (15)]
    [SerializeField] GameObject _platform;
    [Space (15)]
    [SerializeField] GameObject _walls;
    //[SerializeField] Transform _playerTr;
    [Space (15)]
    [SerializeField] NavMeshSurface _suface;
    #endregion

    //Trouver un moyen d'activer et desactiver les bons components de navmesh suface de chaque mur car ils font partie du conflit.

    #region ONTRIGGERENTER
    private void OnTriggerEnter (Collider other)
    {
        PlayerTag Player = other.GetComponentInParent<PlayerTag> ();
        if (Player != null)
        {
            _rbPlayer.isKinematic = true;

            RaycastHit hit;

            //if (Physics.Raycast (_playerTr.position, _playerTr.forward, out hit))
            if (Physics.Raycast (transform.position, transform.forward, out hit))
            {
                if (hit.collider.gameObject.name == "GroundVL")
                {
                    StartCoroutine (StartBake1 ());
                }

                if (hit.collider.gameObject.name == "GroundVR")
                {
                    StartCoroutine (StartBake2 ());
                }
                if (hit.collider.gameObject.name == "Ground1")
                {
                    _platform.transform.rotation = Quaternion.Euler (0, 0, 0);
                }
            }

            _rbPlayer.isKinematic = false;
        }
    }
    #endregion

    #region Coroutine
    IEnumerator StartBake1 ()
    {
        _walls.isStatic= false;
        yield return new WaitForSeconds (5f);
        AntiRotate ();
        yield return new WaitForSeconds (10f);
        _suface.RemoveData ();
        yield return new WaitForSeconds (1f);
        _walls.isStatic = true;
        yield return new WaitForSeconds (2f);
        _suface.BuildNavMesh ();
    }

    IEnumerator StartBake2 ()
    {
        _walls.isStatic = false;
        yield return new WaitForSeconds (5f);
        Rotate ();
        yield return new WaitForSeconds (10f);
        _suface.RemoveData ();
        yield return new WaitForSeconds (1f);
        _walls.isStatic = true;
        yield return new WaitForSeconds (2f);
        _suface.BuildNavMesh ();
    }
    #endregion

    #region GroundRotation
    public void AntiRotate ()
    {
        _platform.transform.rotation = Quaternion.Euler (0, 0, -90f);
    }

    public void Rotate ()
    {
        _platform.transform.rotation = Quaternion.Euler (0, 0, 90);
    }
    #endregion
}
