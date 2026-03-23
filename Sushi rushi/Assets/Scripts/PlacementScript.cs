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
    [SerializeField] Sprite cookedRiceSprite;
    [SerializeField] Sprite plateSprite;
    [SerializeField] Sprite avocadoSlicesSprite;
    [SerializeField] Sprite salmonCutsSprite;



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
        else if (player.currentItem == ItemType.AvocadoSlices)
        {
            if (!isPlaced)
            {
                Debug.Log("Placed down AvocadoSlices");
                player.currentItem = ItemType.None;
                ppSpriteRenderer.sprite = avocadoSlicesSprite;
                gpSpriteRenderer.sprite = null;
                isPlaced = true;
            }
        }
        else if (player.currentItem == ItemType.SalmonCuts)
        {
            if (!isPlaced)
            {
                Debug.Log("Placed down SalmonCuts");
                player.currentItem = ItemType.None;
                ppSpriteRenderer.sprite = salmonCutsSprite;
                gpSpriteRenderer.sprite = null;
                isPlaced = true;
            }
        }
        else if(player.currentItem == ItemType.CookedRice)
        {
            if(!isPlaced)
            {
                Debug.Log("Placed down CookedRiceSprite");
                player.currentItem = ItemType.None;
                ppSpriteRenderer.sprite = cookedRiceSprite;
                gpSpriteRenderer.sprite = null;
                isPlaced = true;
            }
        }
        else if (player.currentItem == ItemType.Plate)
        {
            if (!isPlaced)
            {
                Debug.Log("Placed down Plate");
                player.currentItem = ItemType.None;
                ppSpriteRenderer.sprite = plateSprite;
                gpSpriteRenderer.sprite = null;
                isPlaced = true;
            }
        }
        //Isnt placed




        //Isplaced
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
                else if (ppSpriteRenderer.sprite == avocadoSlicesSprite)
                {
                    Debug.Log("Picked up from counter");
                    player.currentItem = ItemType.AvocadoSlices;
                    gpSpriteRenderer.sprite = avocadoSlicesSprite;
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

                else if(ppSpriteRenderer.sprite == cookedRiceSprite)
                {
                    Debug.Log("Picked up from counter");
                    player.currentItem = ItemType.CookedRice;
                    gpSpriteRenderer.sprite = cookedRiceSprite;
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
                else if (ppSpriteRenderer.sprite == salmonCutsSprite)
                {
                    Debug.Log("Picked up from counter");
                    player.currentItem = ItemType.SalmonCuts;
                    gpSpriteRenderer.sprite = salmonCutsSprite;
                    ppSpriteRenderer.sprite = null;
                    isPlaced = false;
                }

                else if (ppSpriteRenderer.sprite == plateSprite)
                {
                    Debug.Log("Picked up from counter");
                    player.currentItem = ItemType.Plate;
                    gpSpriteRenderer.sprite = plateSprite;
                    ppSpriteRenderer.sprite = null;
                    isPlaced = false;
                }
            }
        }

        
    }
}
