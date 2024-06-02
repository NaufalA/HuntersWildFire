using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMelee : MonoBehaviour
{
    public Weapon weapon;
    
    private Animator _animator;
    [SerializeField] private Transform hitspot;
    [SerializeField] private LayerMask enemyLayers;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        hitspot.localPosition = weapon.Hitspot;
        _animator = gameObject.GetComponent<Animator>();
        _playerMovement = gameObject.GetComponent<PlayerMovement>();
    }

    public void Attack(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && _playerMovement.Grounded)
        {
            _animator.SetTrigger("attackA");
            var hits = Physics2D.OverlapCircleAll(hitspot.position, weapon.Range, enemyLayers);
            foreach (var hit in hits)
            {
                hit.GetComponent<EnemyHealth>().TakeDamage(weapon.Damage, transform);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(
            new Vector3(
                (transform.position.x + weapon.Hitspot.x * transform.localScale.x), 
                transform.position.y + weapon.Hitspot.y, 
                0f
            ),
            weapon.Range
        );
    }
}