using UnityEngine;

public class PlacementScript : Station
{
    SpriteRenderer spriteRenderer;

    [SerializeField] GameObject grabPoint;

    [SerializeField] GameObject avocado;
    [SerializeField] GameObject rice;
    [SerializeField] GameObject salmon;


    [SerializeField] Transform placementTarget;

    private void Start()
    {
        spriteRenderer = grabPoint.GetComponent<SpriteRenderer>();
    }




    public override void Interact(PlayerController player)
    {
        print("Interacted");

        if(player.currentItem == ItemType.Rice )
        {
            Instantiate(rice, placementTarget.position, Quaternion.identity);
            player.currentItem = ItemType.None;
            spriteRenderer.sprite = null;
            
        }
        else if(player.currentItem == ItemType.Salmon )
        {
            Instantiate(salmon, placementTarget.position, Quaternion.identity);
            player.currentItem = ItemType.None;
            spriteRenderer.sprite = null;

        }
        else if(player.currentItem == ItemType.Avocado)
        {
            Instantiate(avocado, placementTarget.position, Quaternion.identity);
            player.currentItem = ItemType.None;
            spriteRenderer.sprite = null;
        }
    }
}
