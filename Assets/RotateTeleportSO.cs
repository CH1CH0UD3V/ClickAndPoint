using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu (fileName = "RotateTeleportSO", menuName = "ScriptSO/RotateTeleportSO")]
public class RotateTeleportSO : ScriptableObject
{
    [SerializeField] Transform _grounds;

    public void AntiRotate ()
    {
        _grounds.rotation = Quaternion.Euler (0, 0, -90f);
    }

    public void Rotate ()
    {
        _grounds.rotation = Quaternion.Euler (0, 0, 90);
    }
}