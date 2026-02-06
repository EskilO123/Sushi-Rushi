using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 6f;
    [Tooltip("Hur mjukt den startar/stannar.")]
    [SerializeField] private float movementSmoothing = 0.05f;

    [Header("Interaction Settings")]
    [SerializeField] private LayerMask interactLayer;
    [SerializeField] private float interactRange = 0.8f;

    
    [Header("Status")]
    public ItemType currentItem = ItemType.None;

    
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private Vector2 currentVelocity;
    private Vector2 lastInteractionDir = Vector2.down; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

        
        if (moveInput.sqrMagnitude > 0.01f)
        {
            lastInteractionDir = moveInput.normalized;
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
    }

    private void HandleMovement()
    {
        Vector2 targetVelocity = moveInput * moveSpeed;

       
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
        }
    }
}