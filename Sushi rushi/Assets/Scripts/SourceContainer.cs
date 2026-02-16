using UnityEngine;

public class SourceStation : Station
{
    public ItemType itemToGive;

    public override void Interact(PlayerController player)
    {
        print("Collected");
        
        if (player.currentItem == ItemType.None)
        {
            player.currentItem = itemToGive;
            
           
        }
    }
}