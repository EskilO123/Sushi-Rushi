using System;
using UnityEngine;

public class WorkStation : Station
{
    public ItemType itemOnTable = ItemType.None;

    SpriteRenderer gpSpriteRenderer;
    SpriteRenderer ppSpriteRenderer;

    [SerializeField] GameObject grabPoint;
    [SerializeField] GameObject placementPoint;

    [SerializeField] Sprite cookedRiceSprite;
    [SerializeField] Sprite salmonCutsSprite;
    [SerializeField] Sprite avocadoSlicesSprite;
    [SerializeField] Sprite sushiSalmonSprite;
    [SerializeField] Sprite sushiAvocadoSprite;

    private void Start()
    {
        gpSpriteRenderer = grabPoint.GetComponent<SpriteRenderer>();
        ppSpriteRenderer = placementPoint.GetComponent<SpriteRenderer>();
    }
    public override void Interact(PlayerController player)
    {
        
        if (((itemOnTable == ItemType.None && player.currentItem == ItemType.CookedRice) ||
            (itemOnTable == ItemType.None && player.currentItem == ItemType.SalmonCuts) ||
            (itemOnTable == ItemType.None && player.currentItem == ItemType.AvocadoSlices)))
        {
            Debug.Log("Put item on assembly table");
            itemOnTable = player.currentItem;
            player.currentItem = ItemType.None;
            gpSpriteRenderer.sprite = null;
        }
        else if (itemOnTable != ItemType.None && player.currentItem == ItemType.None)
        {
            player.currentItem = itemOnTable;
            if (itemOnTable == ItemType.CookedRice)
            {
                gpSpriteRenderer.sprite = cookedRiceSprite;
            }
            else if (itemOnTable == ItemType.SalmonCuts)
            {
                gpSpriteRenderer.sprite = salmonCutsSprite;
            }
            else if (itemOnTable == ItemType.AvocadoSlices)
            {
                gpSpriteRenderer.sprite = avocadoSlicesSprite;
            }
            else if (itemOnTable == ItemType.SushiSalmon)
            {
                gpSpriteRenderer.sprite = sushiSalmonSprite;
            }
            else if (itemOnTable == ItemType.SushiAvocado)
            {
                gpSpriteRenderer.sprite = sushiAvocadoSprite;
            }
            itemOnTable = ItemType.None;
            ppSpriteRenderer.sprite = null;
        }
        
        else if (itemOnTable != ItemType.None && player.currentItem != ItemType.None)
        {
            Combine(player);
        }

        if (itemOnTable == ItemType.CookedRice)
        {
            ppSpriteRenderer.sprite = cookedRiceSprite;
        }
        else if (itemOnTable == ItemType.SalmonCuts)
        {
            ppSpriteRenderer.sprite = salmonCutsSprite;
        }
        else if (itemOnTable == ItemType.AvocadoSlices)
        {
            ppSpriteRenderer.sprite = avocadoSlicesSprite;
        }
    }


    void Combine(PlayerController player)
    {
        
        if ((itemOnTable == ItemType.CookedRice && player.currentItem == ItemType.SalmonCuts) ||
            (itemOnTable == ItemType.SalmonCuts && player.currentItem == ItemType.CookedRice))
        {
            itemOnTable = ItemType.SushiSalmon;
            player.currentItem = ItemType.None;
            gpSpriteRenderer.sprite = null;
            ppSpriteRenderer.sprite = sushiSalmonSprite;
            Debug.Log("Made Sushi Salmon!");
        }
        
        else if ((itemOnTable == ItemType.CookedRice && player.currentItem == ItemType.AvocadoSlices) ||
                 (itemOnTable == ItemType.AvocadoSlices && player.currentItem == ItemType.CookedRice))
        {
            itemOnTable = ItemType.SushiAvocado;
            player.currentItem = ItemType.None;
            gpSpriteRenderer.sprite = null;
            ppSpriteRenderer.sprite = sushiAvocadoSprite;
            Debug.Log("Made Sushi Avocado!");
        }
    }
}
