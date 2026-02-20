using Unity.VisualScripting;
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
        
        if (player.currentItem == ItemType.Rice)
        {
            player.currentItem = itemToGive;


        }

        if (player.currentItem == ItemType.Salmon)
        {
            player.currentItem = itemToGive;


        }

        if (player.currentItem == ItemType.RicePlate)
        {
            player.currentItem = itemToGive;


        }

        if (player.currentItem == ItemType.Plate)
        {
            player.currentItem = itemToGive;


        }
    }
}