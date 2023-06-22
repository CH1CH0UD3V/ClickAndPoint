using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    #region Champs
    [SerializeField] InputActionReference _mousePosition;
    
    NavMeshAgent _agent;
    Camera _mainCamera;
    bool _isClicked;
    RaycastHit hit;
    #endregion

    #region Start
    void Start ()
    {
        _agent = GetComponent<NavMeshAgent>();
        _mainCamera = Camera.main;
    }
    #endregion

    #region OnEnable
    private void OnEnable ()
    {
        _mousePosition.action.performed += MouseClick;
        _mousePosition.action.canceled += MouseUnclick;
    }
    #endregion

    #region OnDisable
    private void OnDisable ()
    {
        _mousePosition.action.performed -= MouseClick;
        _mousePosition.action.canceled -= MouseUnclick;
    }
    #endregion

    #region Update
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
    #endregion

    #region Input
    private void MouseClick (InputAction.CallbackContext obj)
    {
        _isClicked = true;
    }
    private void MouseUnclick (InputAction.CallbackContext obj)
    {
        _isClicked = false;
    }
    #endregion
}
