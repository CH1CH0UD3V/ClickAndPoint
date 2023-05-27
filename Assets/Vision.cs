using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    PlayerBehaviour _player;

    private void OnTriggerEnter (Collider other)
    {

    }

    void EnemyMovement (Collider other)
    {
        _player = other.GetComponentInParent<PlayerBehaviour> (out PlayerBehaviour Player);
        if (_player)
        {
            var origin = transform.position;
            var direction = Player.transform.position;
        }
    }
}
