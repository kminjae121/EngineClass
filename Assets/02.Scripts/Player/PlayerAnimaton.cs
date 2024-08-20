using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimaton : MonoBehaviour
{
    [SerializeField] private PlayerMove _playerMove;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MoveAnimate();
        JumpAnimate();
    }

    private void MoveAnimate()
    {
        if(_playerMove._xmove.x != 0)
        {
            _animator.SetBool("Walk", true);
        }
        else
        {
            _animator.SetBool("Walk", false);
        }
    }
    private void JumpAnimate()
    {
        if (_playerMove._isGround == false)
        {
            _animator.SetBool("Jump", true);
        }
        else
        {
            _animator.SetBool("Jump", false);
        }
    }
}
