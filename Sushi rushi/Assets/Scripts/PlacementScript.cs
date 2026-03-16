using UnityEngine;

public class PlacementScript : Station
{
    SpriteRenderer gpSpriteRenderer;
    SpriteRenderer ppSpriteRenderer;

    [SerializeField] GameObject grabPoint;
    [SerializeField] GameObject placementPoint;

    [SerializeField] Sprite avocadoSprite;
    [SerializeField] Sprite riceSprite;
    [SerializeField] Sprite salmonSprite;

    [SerializeField] Transform placementTarget;

   [SerializeField] bool isPlaced = false;

    private void Start()
    {
        gpSpriteRenderer = grabPoint.GetComponent<SpriteRenderer>();
        ppSpriteRenderer = placementPoint.GetComponent<SpriteRenderer>();
    }



    public override void Interact(PlayerController player)
    {
        print("Interacted");

        if (player.currentItem == ItemType.Rice )
        {
            if (!isPlaced)
            {
                player.currentItem = ItemType.None;
                ppSpriteRenderer.sprite = riceSprite;
                gpSpriteRenderer.sprite = null;
                isPlaced = true;
            }
        }
        else if (player.currentItem == ItemType.Salmon )
        {
            if (!isPlaced)
            {
                player.currentItem = ItemType.None;
                ppSpriteRenderer.sprite = salmonSprite;
                gpSpriteRenderer.sprite = null;
                isPlaced = true;
            }
        }
        else if (player.currentItem == ItemType.Avocado)
        {
            if (!isPlaced)
            {
                Debug.Log("Placed down avocado");
                player.currentItem = ItemType.None;
                ppSpriteRenderer.sprite = avocadoSprite;
                gpSpriteRenderer.sprite = null;
                isPlaced = true;
            }
        }
        else if (player.currentItem == ItemType.None)
        {
            if (isPlaced)
            {
                if (ppSpriteRenderer.sprite == avocadoSprite)
                {
                    Debug.Log("Picked up from counter");
                    player.currentItem = ItemType.Avocado;
                    gpSpriteRenderer.sprite = avocadoSprite;
                    ppSpriteRenderer.sprite = null;
                    isPlaced = false;
                }
                else if (ppSpriteRenderer.sprite == riceSprite)
                {
                    Debug.Log("Picked up from counter");
                    player.currentItem = ItemType.Rice;
                    gpSpriteRenderer.sprite = riceSprite;
                    ppSpriteRenderer.sprite = null;
                    isPlaced = false;
                }
                else if (ppSpriteRenderer.sprite == salmonSprite)
                {
                    Debug.Log("Picked up from counter");
                    player.currentItem = ItemType.Salmon;
                    gpSpriteRenderer.sprite = salmonSprite;
                    ppSpriteRenderer.sprite = null;
                    isPlaced = false;
                }
            }
        }

        //  if (isPlaced)
        // {
        //    if (player.currentItem == ItemType.None)
        // {
        //       player.currentItem = ItemType.Rice;
        //      gpSpriteRenderer.sprite = riceSprite;
        //      ppSpriteRenderer.sprite = null;
        // }
        // }
    }
}
