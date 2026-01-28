using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    bool Haspickup = false;
    [SerializeField] float pickUpDelay = 0.1f;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Pickup") && !Haspickup)
        {
            Haspickup = true;
            Destroy(other.gameObject, pickUpDelay);
            Debug.Log("PickedUp");
        }
    }

}
