using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementComponent : MonoBehaviour
{
    public float speed;
    public Vector2 currentDirection;
    public Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
        _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Start()
    {
        Move(currentDirection);
    }
    private void FixedUpdate()
    {
        UpdateVelocity();
    }
    public void Move(Vector2 direction)
    {
        currentDirection = direction;
    }

    public void Stop()
    {
        currentDirection = Vector2.zero;
    }

    private void UpdateVelocity()
    {

        _rb.velocity = currentDirection * speed * Time.deltaTime;
    }
}
