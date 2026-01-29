using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionScript : MonoBehaviour
{
    

    [SerializeField] private Transform grabPoint;
    [SerializeField] private Transform rayPoint;
    [SerializeField] private float rayDistance;
   
    public GameObject Boxitem;

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
        CollisionDetector();
    }


   
    private void CollisionDetector()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.up, rayDistance);

        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
        {
            if (interactionAction.WasPressedThisFrame() && isHolding == false)
            {

                Boxitem = hitInfo.collider.gameObject;
                Boxitem.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                Instantiate(Boxitem, grabPoint.position,Quaternion.identity);
                Boxitem.transform.SetParent(transform);
                isHolding = true;

            }
            else if (interactionAction.WasPressedThisFrame())
            {
                Boxitem.transform.SetParent(null);
                Boxitem = null;
                isHolding = false;
            }
        }

        Debug.DrawRay(rayPoint.position, transform.up * rayDistance);
        
    }

}
