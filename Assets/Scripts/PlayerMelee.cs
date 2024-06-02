using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerMelee : MonoBehaviour
{
    public Weapon weapon;
    [SerializeField] private Transform hitspot;
    [SerializeField] private LayerMask enemyLayers;

    private Animator _animator;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        hitspot.localPosition = weapon.Hitspot;
        _animator = gameObject.GetComponent<Animator>();
        _playerMovement = gameObject.GetComponent<PlayerMovement>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(
            new Vector3(
                transform.position.x + weapon.Hitspot.x * transform.localScale.x,
                transform.position.y + weapon.Hitspot.y,
                0f
            ),
            weapon.Range
        );
    }

    public void Attack(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && _playerMovement.Grounded)
        {
            if (ctx.interaction is TapInteraction)
            {
                _animator.SetTrigger("attackA");
                Collider2D[] hits = Physics2D.OverlapCircleAll(hitspot.position, weapon.Range, enemyLayers);
                foreach (var hit in hits) hit.GetComponent<EnemyHealth>().TakeDamage(weapon.Damage, transform);
            }
        }
    }

    public void EnableAttacking()
    {
        _animator.SetBool("attacking", true);
    }

    public void DisableAttacking()
    {
        _animator.SetBool("attacking", false);
    }
}