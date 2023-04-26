using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        MoveToForward();
    }

    private void MoveToForward()
    {
        transform.Translate(transform.up * _speed * Time.deltaTime * -1);
    }
}
