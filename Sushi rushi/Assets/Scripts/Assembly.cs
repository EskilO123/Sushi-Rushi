using UnityEngine;

public class WorkStation : Station
{
    public ItemType itemOnTable = ItemType.None;

    public override void Interact(PlayerController player)
    {
        
        if (itemOnTable == ItemType.None && player.currentItem != ItemType.None)
        {
            itemOnTable = player.currentItem;
            player.currentItem = ItemType.None;
        }
        
        else if (itemOnTable != ItemType.None && player.currentItem == ItemType.None)
        {
            player.currentItem = itemOnTable;
            itemOnTable = ItemType.None;
        }
        
        else if (itemOnTable != ItemType.None && player.currentItem != ItemType.None)
        {
            Combine(player);
        }

        
    }

    void Combine(PlayerController player)
    {
        
        if ((itemOnTable == ItemType.RicePlate && player.currentItem == ItemType.SalmonCuts) ||
            (itemOnTable == ItemType.SalmonCuts && player.currentItem == ItemType.RicePlate))
        {
            itemOnTable = ItemType.SushiSalmon;
            player.currentItem = ItemType.None;
            Debug.Log("Made Sushi Salmon!");
        }
        
        else if ((itemOnTable == ItemType.RicePlate && player.currentItem == ItemType.AvocadoSlices) ||
                 (itemOnTable == ItemType.AvocadoSlices && player.currentItem == ItemType.RicePlate))
        {
            itemOnTable = ItemType.SushiAvocado;
            player.currentItem = ItemType.None;
            Debug.Log("Made Sushi Avocado!");
        }
    }
}
