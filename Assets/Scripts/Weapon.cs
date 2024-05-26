using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Inventory/Equipment/Weapon", order = 0)]
public class Weapon : ScriptableObject
{
    [SerializeField]
    private float damage;

    public float Damage => damage;

    public Sprite sprite;
}