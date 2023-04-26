using UnityEngine;

[CreateAssetMenu(fileName = "A_Enemy", menuName = "Unit/Enemy", order = 51)]
public class EnemyAttributes : UnitAttributes
{
    public Sprite Sprite => _sprite;
    public RuntimeAnimatorController AnimatorController => _controller;
    public Vector2 ColliderRadius => _colliderRadius;
    public CapsuleDirection2D ColliderDirection => _colliderDirection;

    [SerializeField] private Sprite _sprite;
    [SerializeField] private RuntimeAnimatorController _controller;
    [SerializeField] private Vector2 _colliderRadius;
    [SerializeField] private CapsuleDirection2D _colliderDirection;
}
