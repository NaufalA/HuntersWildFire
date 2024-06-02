using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class EnemyMelee : MonoBehaviour
{
    [SerializeField] private float collisionDamage;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player") && !col.gameObject.GetComponent<Animator>().GetBool("attacking"))
        {
            col.gameObject.GetComponent<PlayerHealth>().TakeDamage(collisionDamage, transform);
        }
    }
}