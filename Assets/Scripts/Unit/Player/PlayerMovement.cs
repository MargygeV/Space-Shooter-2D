using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private Vector2 _directionMove;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    { 
        _directionMove = new Vector2(Input.GetAxis("Horizontal"), transform.position.y);
        _rigidbody2D.MovePosition(_rigidbody2D.position + _directionMove * _speed * Time.fixedDeltaTime);
        _animator.SetFloat("MoveX", Input.GetAxis("Horizontal"));
    }
}
