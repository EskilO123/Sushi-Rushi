using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionScript : MonoBehaviour
{
    

    [SerializeField] Transform grabPoint;
    [SerializeField] Transform rayPoint;
    [SerializeField] float rayDistance;
    [SerializeField] ContainerSO containerContents;
   
    [SerializeField] GameObject redboxItem;
    GameObject heldItem;

    int objectLayer;
    int containerLayer;
    bool isHolding = false;

    InputAction interactionAction;

    void Start()
    {
        containerLayer = LayerMask.NameToLayer("Box");
        objectLayer = LayerMask.NameToLayer("Objects");
       
        interactionAction = InputSystem.actions.FindAction("Interact");
    }

    
    void Update()
    {
        GrabDetector();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FishContainer"))
        {
            
        }
    }

    void GrabDetector()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.up, rayDistance);

        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == containerLayer)
        {
            if (interactionAction.WasPressedThisFrame())
            {
                if (!isHolding)
                {

                    heldItem = Instantiate(containerContents.GetContainedObject(), grabPoint.position, Quaternion.identity);
                    heldItem.transform.SetParent(grabPoint);
                    isHolding = true;
                }
                else if (isHolding)
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
                    else if (isHolding)
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
