using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public void RaySensor ()
    {
        RaycastHit hit;

        if (Physics.Raycast (transform.position, transform.forward, out hit))
        {
            if (hit.collider.gameObject.name == "GroundVL")
            {
                
            }

            if (hit.collider.gameObject.name == "GroundVR")
            {

            }
        }
    }
}
