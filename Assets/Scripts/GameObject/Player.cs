using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private float _movingSpeed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {

    }
}
