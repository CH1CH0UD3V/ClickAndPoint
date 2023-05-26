using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] InputActionReference _mouseDelta;
    [SerializeField] NavMeshAgent _agent;
    Camera _mainCamera;
    bool _isClicked;
    RaycastHit hit;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _mainCamera = Camera.main;

        _mouseDelta.action.performed += MouseClick;
        _mouseDelta.action.canceled += MouseUnclick; ;
    }

    private void Update ()
    {
        if (_isClicked)
        {
            Ray ray = _mainCamera.ScreenPointToRay (Mouse.current.position.ReadValue ());

            if (Physics.Raycast (ray, out hit, Mathf.Infinity))
            {
                _agent.SetDestination (hit.point);
            }
        }
    }

    void OnDrawGizmos ()
    {
        if (_isClicked && _agent.hasPath)
        {
            NavMeshPath path = _agent.path;
            Vector3[] corners = path.corners;

            for (int i = 0; i < corners.Length - 1; i++)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine (corners[i], corners[i + 1]);
            }
        }
    }

    private void MouseClick (InputAction.CallbackContext obj)
    {
        _isClicked = true;
    }
    private void MouseUnclick (InputAction.CallbackContext obj)
    {
        _isClicked = false;
    }
}
