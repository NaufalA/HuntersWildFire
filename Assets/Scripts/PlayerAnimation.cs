using System;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _animator.SetFloat("deltaX", _rb.velocity.normalized.x);
        _animator.SetFloat("deltaY", _rb.velocity.normalized.y);
    }
}