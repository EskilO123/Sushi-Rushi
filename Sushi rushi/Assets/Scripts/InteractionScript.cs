using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionScript : MonoBehaviour
{
    [SerializeField] private Transform grabPoint;
    [SerializeField] private Transform rayPoint;
    [SerializeField] private float rayDistance;
    
   
    private GameObject grabbedObject;

    private int layerIndex;
    bool isHolding = false;

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

        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
        {
            if (interactionAction.WasPressedThisFrame() && isHolding == false)
            {

                grabbedObject = hitInfo.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                grabbedObject.transform.position = grabPoint.position;
                grabbedObject.transform.SetParent(transform);
                isHolding = true;

            }
            else if (interactionAction.WasPressedThisFrame())
            {
                grabbedObject.transform.SetParent(null);
                grabbedObject = null;
                isHolding = false;
            }
        }

        Debug.DrawRay(rayPoint.position, transform.right * rayDistance);
        
    }

}
