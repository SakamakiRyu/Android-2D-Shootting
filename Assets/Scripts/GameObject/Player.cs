using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private float _movingSpeed;

    private Rigidbody2D _rb2d;

    private bool IsTouch { get; set; }

    private float _prevInputPosX;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    /// <summary>
    /// à⁄ìÆÇ∑ÇÈ
    /// </summary>
    private void Move()
    {
        var inputPos = Input.mousePosition;

        if (Input.GetButtonDown("Fire1"))
        {
            IsTouch = true;
            _prevInputPosX = inputPos.x;
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            IsTouch = false;
        }

        if (IsTouch)
        {
            var res = CheckInputDirection();

            if (res == InputDirection.Left)
            {
                _rb2d.velocity = Vector2.left * _movingSpeed;
            }
            else if(res == InputDirection.Right)
            {
                _rb2d.velocity = Vector2.right * _movingSpeed;
            }
            else
            {
                _rb2d.velocity = Vector2.zero;
            }
        }
        else
        {
            _rb2d.velocity = Vector2.zero;
        }
    }

    /// <summary>
    /// ì¸óÕÇ™ç∂âEÇ«Ç¡ÇøÇ©
    /// </summary>
    private InputDirection CheckInputDirection()
    {
        if (IsTouch)
        {
            if (_prevInputPosX < Input.mousePosition.x)
            {
                return InputDirection.Right;
            }
            else if (_prevInputPosX > Input.mousePosition.x)
            {
                return InputDirection.Left;
            }
            return InputDirection.None;
        }
        return InputDirection.None;
    }
}
