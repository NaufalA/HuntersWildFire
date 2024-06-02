using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Inventory/Equipment/Weapon", order = 0)]
public class Weapon : ScriptableObject
{
    [SerializeField]
    private float damage;
    [SerializeField] [Tooltip("hitspot relative position to character")]
    private Vector2 hitspot;
    [SerializeField] [Tooltip("hit range")]
    private float range;

    public float Damage => damage;
    public Vector2 Hitspot => hitspot;
    public float Range => range;
}