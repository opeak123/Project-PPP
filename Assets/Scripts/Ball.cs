using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rBody;
    private const float paddleMinY = -4.6f;

    [SerializeField]
    private bool isPlaying = false;

    [SerializeField]
    private Transform originPos;

    //[SerializeField]
    //private float bouncingForce;
    private void Awake()
    {
        rBody =  GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        BouncyBall();
        SetPosition();
    }

    private void SetPosition()
    {
        if(!isPlaying)
        {
            transform.position = originPos.position;
        }
    }

    private void ConstrainY()
    {
        if (this.transform.position.y < paddleMinY)
        {
            rBody.velocity = Vector2.zero;
            rBody.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }

    private void BouncyBall()
    {
        if (Gamepad.current != null && Gamepad.current.xButton.isPressed && !isPlaying)
        {
            isPlaying = true;
            rBody.AddForce(new Vector2(0, GameManager.Instance.ballSpeed));
        }

        if (Keyboard.current != null && 
            Keyboard.current.spaceKey.wasPressedThisFrame && !isPlaying)
        {
            isPlaying = true;
            rBody.AddForce(new Vector2(0, GameManager.Instance.ballSpeed));
            Debug.Log("keyboard : X key is pressed");
        }
    }

    private void BallDirection()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Bottom"))
        {
            isPlaying = false;
            ConstrainY();
            Debug.Log("hit the bottom");
        }
    }
}
