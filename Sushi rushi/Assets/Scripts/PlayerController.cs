using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    
    float playerScale = 1.25f;
    Animator anim;
    Transform grabPointFollow;


    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 6f;
    [Tooltip("How soft it starts and stops.")]
    [SerializeField] private float movementSmoothing = 0.05f;

    [Header("Interaction Settings")]
    [SerializeField] private LayerMask interactLayer;
    [SerializeField] private float interactRange = 0.8f;

    [SerializeField] GameObject grabPoint;

    [Header("Status")]
    public ItemType currentItem = ItemType.None;

    
    private Vector2 moveVector;
    private Rigidbody2D rb;
    private Vector2 currentVelocity;
    private Vector2 lastInteractionDir = Vector2.down;
   
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        grabPointFollow = grabPoint.GetComponent<Transform>();
        anim = GetComponentInChildren<Animator>();
    }

   

    void OnMove(InputValue value)
    {
        moveVector = value.Get<Vector2>();

        
        if (moveVector.sqrMagnitude > 0.01f)
        {
            lastInteractionDir = moveVector.normalized;
        }
    }

    
    void OnInteract(InputValue value)
    {
        if (value.isPressed)
        {
            TryInteract();
        }
    }

    private void FixedUpdate()
    {
        HandleMovement();
        Flip();
        Catmations();
    }

    private void HandleMovement()
    {
        Vector2 targetVelocity = moveVector * moveSpeed;

       
        rb.linearVelocity = Vector2.SmoothDamp(rb.linearVelocity, targetVelocity, ref currentVelocity, movementSmoothing);
    }

    private void TryInteract()
    {
        
        Vector2 interactPos = (Vector2)transform.position + (lastInteractionDir * interactRange);

        
        Collider2D hit = Physics2D.OverlapCircle(interactPos, 0.3f, interactLayer);

        if (hit != null)
        {
            Station station = hit.GetComponent<Station>();
            if (station != null)
            {
                station.Interact(this);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = Color.yellow;
            Vector3 targetPos = transform.position + (Vector3)(lastInteractionDir * interactRange);
            Gizmos.DrawWireSphere(targetPos, 0.3f);
            grabPointFollow.position = targetPos;
            


        }
    }

    private void Flip()
    {
        if(moveVector.x > 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (moveVector.x < 0)
        {
            transform.eulerAngles = new Vector3(0f, -180f, 0f);
        }
    }

    void Catmations()
    {
        if(moveVector != Vector2.zero)
        {
            anim.SetBool("isRunning", true);
        }   else
        {
            anim.SetBool("isRunning", false);
        }
    }
}