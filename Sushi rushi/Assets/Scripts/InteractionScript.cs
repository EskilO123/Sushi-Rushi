using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionScript : MonoBehaviour
{
    [SerializeField] private Transform grabPoint;
    [SerializeField] private Transform rayPoint;
    [SerializeField] private float rayDistance;
    
   
    private GameObject grabbedObject;

    private int layerIndex;

    InputAction interactionAction;

    Rigidbody2D rb;
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Objects");
        interactionAction = InputSystem.actions.FindAction("Interact");


        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        CollisionDetector();
    }

   private void CollisionDetector()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);

        if (interactionAction.IsPressed())
        {
            grabbedObject = hitInfo.collider.gameObject;
            grabbedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            grabbedObject.transform.position = grabPoint.position;
            grabbedObject.transform.SetParent(transform);

        }

        else if (interactionAction.IsPressed())
        {
            grabbedObject.GetComponent<Rigidbody2D>();
            grabbedObject.transform.SetParent(null);
            grabbedObject = null;
        }

        Debug.DrawRay(rayPoint.position, transform.right * rayDistance);
        
    }

}
