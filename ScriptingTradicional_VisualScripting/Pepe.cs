using UnityEngine;
using UnityEngine.InputSystem;

public class Pepe : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private InputActionReference move;

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        moveDirection = move.action.ReadValue<Vector2>();

        if (moveDirection.x > 0.05f)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveDirection.x < -0.05f)
        {
            spriteRenderer.flipX = true;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveDirection * speed;
        animator.SetBool("IsWalking", moveDirection.sqrMagnitude > 0.01f);
    }
}