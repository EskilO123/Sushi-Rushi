using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionScript : MonoBehaviour
{
    

    [SerializeField] Transform grabPoint;
    [SerializeField] Transform rayPoint;
    [SerializeField] float rayDistance;
   
    [SerializeField] GameObject redboxItem;
    GameObject heldItem;

    int objectLayer;
    int containerLayer;
    bool isHolding = false;

    [SerializeField] LayerMask boxLayer;
    InputAction interactionAction;

    Rigidbody2D rb;
    void Start()
    {
        containerLayer = LayerMask.NameToLayer("Box");
        objectLayer = LayerMask.NameToLayer("Objects");
       
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

        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == containerLayer)
        {
            if (interactionAction.WasPressedThisFrame())
            {
                if (!isHolding)
                {

                    heldItem = Instantiate(redboxItem, grabPoint.position, Quaternion.identity);
                    heldItem.transform.SetParent(grabPoint);
                    isHolding = true;
                }
                if (isHolding)
                {
                    // Drop the item
                    heldItem.transform.SetParent(null);
                    heldItem = null;
                    isHolding = false;
                }
                Debug.DrawRay(rayPoint.position, transform.up * rayDistance);
            }
        }
        else if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == objectLayer)
        {
            if (!isHolding)
            {
                if (interactionAction.WasPressedThisFrame())
                {
                    if (!isHolding)
                    {
                        heldItem = hitInfo.collider.gameObject;
                        heldItem.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                        heldItem.transform.position = grabPoint.position;
                        heldItem.transform.SetParent(transform);
                        isHolding = true;
                    }
                    if (isHolding)
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
    }   
}
