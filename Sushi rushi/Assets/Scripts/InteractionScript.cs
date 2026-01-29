using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionScript : MonoBehaviour
{
    

    [SerializeField] private Transform grabPoint;
    [SerializeField] private Transform rayPoint;
    [SerializeField] private float rayDistance;
   
    [SerializeField] private GameObject redboxItem;
    private GameObject heldItem;

    private int layerIndex;
    bool isHolding = false;

    InputAction interactionAction;

    Rigidbody2D rb;
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Box");
        interactionAction = InputSystem.actions.FindAction("Interact");
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        GrabDetector();
    }


   
    private void GrabDetector()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.up, rayDistance);

        if (interactionAction.WasPressedThisFrame())
        {
            if (!isHolding)
            {
                
                heldItem = Instantiate(redboxItem, grabPoint.position, Quaternion.identity);
                heldItem.transform.SetParent(grabPoint);
                isHolding = true;
            }
            else
            {
                // Drop the item
                heldItem.transform.SetParent(null); 
                heldItem = null; 
                isHolding = false; 
            }
            Debug.DrawRay(rayPoint.position, transform.up * rayDistance);
        }
    }
}
