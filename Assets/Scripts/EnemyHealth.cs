using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float healthPoints;

    [SerializeField] private Animator animator;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void TakeDamage(float damage, Transform hitSource)
    {
        healthPoints -= damage;
        animator.SetTrigger("hurt");
        
        if (healthPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetBool("dead", true);
        gameObject.GetComponent<Collider2D>().enabled = false;
    }
}