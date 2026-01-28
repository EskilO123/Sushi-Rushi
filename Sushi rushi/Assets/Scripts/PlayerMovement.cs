using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;

    InputAction moveAction;
    Vector2 moveVector;

    Rigidbody2D rb;

    Animation anim;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");

        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        moveVector = moveAction.ReadValue<Vector2>();

        MovePlayer();
    }

    void MovePlayer()
    {


        if (moveVector.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, -90f);
            rb.linearVelocityX = 1f * moveSpeed * Time.deltaTime;
        }

        else if (moveVector.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 90f);
            rb.linearVelocityX = -1f * moveSpeed * Time.deltaTime;
        }
        else
        {
            rb.linearVelocityX = 0;
        }

        if (moveVector.y > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            rb.linearVelocityY = 1f * moveSpeed * Time.deltaTime;
        }
        else if (moveVector.y < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, -180);
            rb.linearVelocityY = -1f * moveSpeed * Time.deltaTime;
        }
        else
        {
            rb.linearVelocityY = 0;
        }

    }
}