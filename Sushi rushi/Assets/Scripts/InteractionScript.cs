using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    [SerializeField] private Transform grabPoint;
    [SerializeField] private Transform rayPoint;
    [SerializeField] private float rayDistance;
   
    private GameObject grabbedObject;

    private int layerIndex;
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Objects");
    }

    
    void Update()
    {
        CollisionDetector();
    }

   private void CollisionDetector()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            grabbedObject = hitInfo.collider.gameObject;
            grabbedObject.GetComponent<Rigidbody2D>();
            grabbedObject.transform.position = grabPoint.position;
            grabbedObject.transform.SetParent(transform);

        }

        else if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            grabbedObject.GetComponent<Rigidbody2D>();
            grabbedObject.transform.SetParent(null);
            grabbedObject = null;
        }

        Debug.DrawRay(rayPoint.position, transform.right * rayDistance);
        
    }

}
