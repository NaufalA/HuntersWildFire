using System;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float healthPoints;

    private Animator _animator;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float damage, Transform hitSource)
    {
        healthPoints -= damage;
        _animator.SetTrigger("hurt");
        var xDelta = (hitSource.transform.position.x < transform.position.x ? 1 : -1) * 0.5f;
        _rb.DOMoveX(transform.position.x + xDelta, 1).SetEase(Ease.OutExpo);
        
        if (healthPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _animator.SetBool("dead", true);
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerMelee>().enabled = false;
        enabled = false;
    }
}