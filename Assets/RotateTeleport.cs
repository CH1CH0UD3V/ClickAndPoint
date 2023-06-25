using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;

public class RotateTeleport : MonoBehaviour
{
    #region Champ
    [Space (15)]
    [SerializeField] Rigidbody _rbPlayer;
    [Space (15)]
    [SerializeField] GameObject _walls;
    [Space (15)]
    [SerializeField] GameObject _teleportDownL, _teleportDownR, _teleportUpL, _teleportUpR;
    [Space (15)]
    [SerializeField] GameObject _ground1, _groundVR, _groundVL;
    [Space (15)]
    [SerializeField] Animator _animation;
    [Space (15)]
    [SerializeField] NavMeshSurface _suface;


    bool _IsRotate;
    bool _IsAntirotate;
    #endregion

    #region ONTRIGGERENTER
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
                    _IsAntirotate = true;
                    StartCoroutine (StartBake1 ());
                }

                if (hit.collider.gameObject.name == "GroundVR")
                {
                    _IsRotate = true;
                    StartCoroutine (StartBake2 ());
                }
                if (hit.collider.gameObject.name == "Ground1")
                {
                    //_IsAntirotate = false;
                    //_IsRotate = false;
                    _animation.SetBool ("IsAntirotate", false);
                    _animation.SetBool ("IsRotate", false);
                    _teleportDownL.SetActive (true);
                    _teleportDownR.SetActive (true);
                    _teleportUpL.SetActive (false);
                    _teleportUpR.SetActive (false);
                    _ground1.GetComponent<NavMeshSurface> ().enabled = true;
                    _groundVL.GetComponent<NavMeshSurface> ().enabled = false;
                    _groundVR.GetComponent<NavMeshSurface> ().enabled = false;
                }
            }

            //_rbPlayer.isKinematic = false;
        }
    }
    #endregion

    #region Coroutine Bake NavMesh
    IEnumerator StartBake1 ()
    {
        _suface.RemoveData ();
        _walls.isStatic= false;
        AntiRotate ();
        _teleportDownL.SetActive(false);
        _teleportDownR.SetActive(false);
        _teleportUpL.SetActive (true);
        _teleportUpR.SetActive (true);
        yield return new WaitForSeconds (5f * Time.deltaTime);
        _walls.isStatic = true;
        _suface.BuildNavMesh ();
    }

    IEnumerator StartBake2 ()
    {
        _suface.RemoveData ();
        _walls.isStatic = false;
        Rotate ();
        _teleportDownL.SetActive (false);
        _teleportDownR.SetActive (false);
        _teleportUpL.SetActive (true);
        _teleportUpR.SetActive (true);
        yield return new WaitForSeconds (5f * Time.deltaTime);
        _walls.isStatic = true;
        _suface.BuildNavMesh ();
    }
    #endregion

    #region GroundRotation
    void AntiRotate ()
    {
        _animation.SetBool ("IsAntirotate", _IsAntirotate);
        _ground1.GetComponent<NavMeshSurface> ().enabled = false;
        _groundVL.GetComponent<NavMeshSurface> ().enabled = true;
        _groundVR.GetComponent<NavMeshSurface> ().enabled = false;
    }

    void Rotate ()
    {
        _animation.SetBool ("IsRotate", _IsRotate);
        _ground1.GetComponent<NavMeshSurface> ().enabled = false;
        _groundVL.GetComponent<NavMeshSurface> ().enabled = false;
        _groundVR.GetComponent<NavMeshSurface> ().enabled = true;
    }
    #endregion
}
