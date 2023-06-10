using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu (fileName = "RotateTeleportSO", menuName = "ScriptSO/RotateTeleportSO")]
public class RotateTeleportSO : ScriptableObject
{
    [SerializeField] Transform _grounds;
    [SerializeField] Material _groundColor;

    #region GroundRotation
    public void AntiRotate ()
    {
        _grounds.rotation = Quaternion.Euler (0, 0, -90f);
    }

    public void Rotate ()
    {
        _grounds.rotation = Quaternion.Euler (0, 0, 90);
    }
    #endregion

    #region ColorDetection
    public void ChangeColorDetect ()
    {
        _groundColor.color = Color.blue;
    }

    public void ChangeColorUnDetect ()
    {
        _groundColor.color = Color.magenta;
    }
    #endregion
}