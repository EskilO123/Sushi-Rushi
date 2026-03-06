using NUnit.Framework.Constraints;
using NUnit.Framework.Internal.Filters;
using Unity.VisualScripting;
using UnityEngine;

public class SourceStation : Station
{
   public ItemType itemToGive;

   public SpriteRenderer spriteRenderer;

    [SerializeField] public GameObject grabPoint;

    [SerializeField] public Sprite riceSprite;
    [SerializeField] Sprite avocadoSprite;
    [SerializeField] Sprite salmonSprite;

    bool isHolding = false;

    void Start()
    {
        spriteRenderer = grabPoint.GetComponent<SpriteRenderer>();
    }

    public override void Interact(PlayerController player)
    {

        
        print("Collected");

        
           



        if (player.currentItem == ItemType.None)
        {
            player.currentItem = itemToGive;
            spriteRenderer.sprite = null;
            
        }
        
        if (player.currentItem == ItemType.Rice)
        {
            player.currentItem = itemToGive;
            spriteRenderer.sprite = riceSprite;
            
            Debug.Log("Changed sprite to ricesprite");
        }

        if (player.currentItem == ItemType.Avocado)
        {
            player.currentItem = itemToGive;
            spriteRenderer.sprite = avocadoSprite;
            
            Debug.Log("Changed sprite to avocadosprite");
        }

        if (player.currentItem == ItemType.Salmon)
        {
            player.currentItem = itemToGive;
            spriteRenderer.sprite = salmonSprite;
            
            Debug.Log("Changed sprite to salmonSprite");

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