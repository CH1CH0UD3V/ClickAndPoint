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

            if (_agent.hasPath)
            {
                Vector3[] corners = _agent.path.corners;

                for (int i = 0; i < corners.Length - 1; i++)
                {
                    Debug.DrawLine (corners[i], corners[i + 1], Color.green);
                }
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
