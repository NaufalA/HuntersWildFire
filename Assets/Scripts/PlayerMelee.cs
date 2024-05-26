using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMelee : MonoBehaviour
{
    public Weapon weapon;
    
    [SerializeField] private GameObject weaponObject;
    [SerializeField] private GameObject weaponHitbox;
    private Animator _animator;
    [SerializeField] private LayerMask enemyLayers;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        weaponObject.GetComponent<SpriteRenderer>().sprite = weapon.sprite;
    }

    public void Attack(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && _playerMovement.Grounded)
        {
            Debug.Log("attackperformed");
            _animator.SetTrigger("attackA");
            weaponHitbox.SetActive(true);
            var hits = Physics2D.OverlapCircleAll(weaponHitbox.transform.position, 0.2f, enemyLayers);
            foreach (var hit in hits)
            {
                hit.GetComponent<EnemyHealth>().TakeDamage(weapon.Damage);
            }
        }
        if (ctx.canceled)
        {
            Debug.Log("attackCancelled");
            weaponHitbox.SetActive(false);
        }
    }

    public void EnableHitbox()
    {
    }

    public void DisableHitbox()
    {
    }
}