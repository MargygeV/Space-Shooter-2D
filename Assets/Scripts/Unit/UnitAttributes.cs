using UnityEngine;

[CreateAssetMenu(fileName = "A_Unit", menuName = "Unit/Unit", order = 51)]
public class UnitAttributes : ScriptableObject
{
    public float Health => _health;
    public float Damage => _damage;

    [SerializeField] private float _health;
    [SerializeField] private float _damage;
}
