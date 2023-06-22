using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu (fileName = "RotateTeleportSO", menuName = "ScriptSO/RotateTeleportSO")]
public class RotateTeleportSO : ScriptableObject
{
    [SerializeField] GameObject _ground;
    [SerializeField] Material _groundColor;

    #region GroundRotation
    public void AntiRotate ()
    {
        _ground.transform.rotation = Quaternion.Euler (0, 0, -90f);
    }

    public void Rotate ()
    {
        _ground.transform.rotation = Quaternion.Euler (0, 0, 90);
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