using UnityEngine;

[CreateAssetMenu(fileName = "A_Bullet", menuName = "Bullet", order = 51)]
public class BulletAttributes : ScriptableObject
{
    public float DamageMultiplier => _damageMultiplier;
    public float Speed => _speed;
    public Sprite Sprite => _sprite;

    [SerializeField] private float _damageMultiplier;
    [SerializeField] private float _speed;
    [SerializeField] private Sprite _sprite;
}
