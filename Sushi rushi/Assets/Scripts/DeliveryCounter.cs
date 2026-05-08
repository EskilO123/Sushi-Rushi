using UnityEngine;

public class DeliveryCounter : Station
{
    [Header("Score Settings")]
    public int baseScore = 100;
    public int rushiModeBonus = 50;
    

    public override void Interact(PlayerController player)
    {
        
        if (player.currentItem == ItemType.None)
        {
            Debug.Log("You have nothing to deliver!");
            return;
        }

        
        RecipeType? recipeType = ConvertToRecipeType(player.currentItem);

       
        if (recipeType == null)
        {
            Debug.Log("This isn't a finished dish!");
            return;
        }

        
        bool success = OrderManager.Instance.DeliverOrder(recipeType.Value);

        if (success)
        {
            
            int scoreToAdd = baseScore;

            if (GameManager.Instance.isSushiRushiActive)
            {
                scoreToAdd += rushiModeBonus;
                Debug.Log($"Sushi Rushi Bonus! +{rushiModeBonus}");
            }

            GameManager.Instance.AddScore(scoreToAdd);
            Debug.Log($"Delivery Success! +{scoreToAdd} points");

           
            player.currentItem = ItemType.None;
        }
       
    }

    private RecipeType? ConvertToRecipeType(ItemType item)
    {
        switch (item)
        {
            case ItemType.SushiSalmon:
                return RecipeType.SalmonSushi;
            case ItemType.SushiAvocado:
                return RecipeType.AvocadoSushi;
            default:
                return null;
        }
    }
}