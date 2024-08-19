using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private InputReader _playerInputSO;
    [SerializeField] private Transform _groundChecker;
    private bool _isSecondJump;
    private bool _isGround;
    [SerializeField] private Player _player;
    public LayerMask WhatIsGround;
    public Vector2 BoxSize;
    private Rigidbody2D _rigid;
    private Vector2 _xmove;
    public float JumpSpeed; 
    public float MoveSpeed;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _isSecondJump = false;
    }
    private void Update()
    {
        CheckGround();
    }

    private void CheckGround()
    {
        _isGround = Physics2D.OverlapBox(_groundChecker.position, BoxSize, 0, WhatIsGround);
    }    

    public void Jump()
    {
        if (_isGround)
        {
            _rigid.velocity = Vector2.zero;
            _rigid.AddForce(Vector2.up * JumpSpeed, ForceMode2D.Impulse);
            _isSecondJump = true;
        }

        else if (_isSecondJump == true)
        {
            _rigid.velocity = Vector2.zero;
            _rigid.AddForce(Vector2.up * JumpSpeed, ForceMode2D.Impulse);

            _isSecondJump = false;
        }
    }

    public void SetMoveMent(Vector2 value)
    {
        _xmove = value;
    }

    private void FixedUpdate()
    {
        _rigid.velocity = new Vector2(_xmove.x * MoveSpeed, _rigid.velocity.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_groundChecker.position, BoxSize);
        Gizmos.color = Color.white;
    }
}
