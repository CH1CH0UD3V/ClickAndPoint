using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] InputActionReference _mouseDelta;
    
    NavMeshAgent _agent;
    Camera _mainCamera;
    bool _isClicked;
    RaycastHit hit;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _mainCamera = Camera.main;
    }

    private void OnEnable ()
    {
        _mouseDelta.action.performed += MouseClick;
        _mouseDelta.action.canceled += MouseUnclick;
    }

    private void OnDisable ()
    {
        _mouseDelta.action.performed -= MouseClick;
        _mouseDelta.action.canceled -= MouseUnclick;
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

    private void MouseClick (InputAction.CallbackContext obj)
    {
        _isClicked = true;
    }
    private void MouseUnclick (InputAction.CallbackContext obj)
    {
        _isClicked = false;
    }
}
