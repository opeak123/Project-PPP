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
    private Rigidbody2D rBody;

    private void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        Vector2 targetPosition = rBody.position + inputVector * moveSpeed * Time.fixedDeltaTime;
        Vector2 newPosition = Vector2.Lerp(rBody.position, targetPosition, 0.5f);

        rBody.MovePosition(newPosition);
    }
    private void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Ball"))
        {
            Rigidbody2D ballRb = col.gameObject.GetComponent<Rigidbody2D>();
            Vector2 hitPoint = col.contacts[0].point;
            Vector2 paddleCenter = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y);

            ballRb.velocity = Vector2.zero;

            float dir = paddleCenter.x - hitPoint.x;

            if(hitPoint.x < paddleCenter.x)
            {
                ballRb.AddForce(new Vector2(-(Mathf.Abs(dir * GameManager.Instance.ballSpeed)), GameManager.Instance.ballSpeed));
            }
            else
            {
                ballRb.AddForce(new Vector2((Mathf.Abs(dir * GameManager.Instance.ballSpeed)), GameManager.Instance.ballSpeed));
            }
        }
    }
} 