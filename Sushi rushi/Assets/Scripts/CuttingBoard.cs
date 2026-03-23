using UnityEngine;

public class CuttingStation : Station
{
    public ItemType itemOnBoard = ItemType.None;
    private int currentChops = 0;
    private int chopsRequired = 10;
   
    SpriteRenderer spriteRenderer;
    
    [SerializeField] GameObject grabPoint;
    
    [SerializeField] Sprite avocadoSlicesSprite;
    [SerializeField] Sprite salmonCutsSprite;
    private void Start()
    {
        spriteRenderer = grabPoint.GetComponent<SpriteRenderer>();
    }

    public override void Interact(PlayerController player)
    {
        
        if (itemOnBoard == ItemType.None && IsChoppable(player.currentItem))
        {
            itemOnBoard = player.currentItem;
            player.currentItem = ItemType.None;
            currentChops = 0; 
            Debug.Log("Put " + itemOnBoard + " On Board.");
        }
        
        else if (itemOnBoard != ItemType.None && !IsChopped(itemOnBoard) && player.currentItem == ItemType.None)
        {
            currentChops++;
            
            Debug.Log("Cut: " + currentChops + "/" + chopsRequired);

            if (currentChops >= chopsRequired && itemOnBoard == ItemType.Avocado) 
            {
                ConvertToChopped();
                Debug.Log("Done!");
                spriteRenderer.sprite = avocadoSlicesSprite;
                player.currentItem = ItemType.AvocadoSlices;

            }

            else if(currentChops >= chopsRequired && itemOnBoard == ItemType.Salmon)
            {
                ConvertToChopped();
                Debug.Log("Done!");
                spriteRenderer.sprite = salmonCutsSprite;
                player.currentItem = ItemType.SalmonCuts;
                currentChops = 0;

            }
        }
        
        else if (itemOnBoard != ItemType.None && IsChopped(itemOnBoard) && player.currentItem == ItemType.None)
        {
            player.currentItem = itemOnBoard;
            itemOnBoard = ItemType.None;
            
        }

    }

    bool IsChoppable(ItemType item)
    {
        return item == ItemType.Salmon || item == ItemType.Avocado;
    }

    bool IsChopped(ItemType item)
    {
        return item == ItemType.SalmonCuts || item == ItemType.AvocadoSlices;
    }

    void ConvertToChopped()
    {
        if (itemOnBoard == ItemType.Salmon) itemOnBoard = ItemType.SalmonCuts;
        else if (itemOnBoard == ItemType.Avocado) itemOnBoard = ItemType.AvocadoSlices;
    }
}
