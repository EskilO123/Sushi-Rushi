using Unity.VisualScripting;
using UnityEngine;

public class TrashStation : MonoBehaviour
{
    PlayerController player;
    public ItemType itemToGive;

    SpriteRenderer spriteRenderer;

    [SerializeField] public GameObject grabPoint;

    SourceStation sourceStation;


    void Start()
    {
        spriteRenderer = grabPoint.GetComponent<SpriteRenderer>();
    }

    public void Interact(PlayerController player)
    {
        if (player.currentItem != ItemType.None)
        {
            player.currentItem = ItemType.None;
            spriteRenderer.sprite = null;
        }
      
    }
}
