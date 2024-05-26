using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float healthPoints;

    public void TakeDamage(float damage)
    {
        healthPoints -= damage;
        if (healthPoints <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}