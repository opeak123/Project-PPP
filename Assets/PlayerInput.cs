using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    [Range(1,50)]
    private float moveSpeed = 10f;

    private PlayerInput playerInput;
    private InputAction movementAction;
    private Vector2 inputVector;
    private Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        Vector2 targetPosition = rigidbody.position + inputVector * moveSpeed * Time.fixedDeltaTime;
        Vector2 newPosition = Vector2.Lerp(rigidbody.position, targetPosition, 0.5f);

        rigidbody.MovePosition(newPosition);
    }
    private void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>();
    }
} 