using NUnit.Framework.Constraints;
using NUnit.Framework.Internal.Filters;
using Unity.VisualScripting;
using UnityEngine;

public class SourceStation : Station
{
    PlayerController player;
    public ItemType itemToGive;

    SpriteRenderer spriteRenderer;

    [SerializeField] public GameObject grabPoint;

    [SerializeField] Sprite riceSprite;
    [SerializeField] Sprite avocadoSprite;
    [SerializeField] Sprite salmonSprite;
    [SerializeField] Sprite plateSprite;


    void Start()
    {
        spriteRenderer = grabPoint.GetComponent<SpriteRenderer>();

    }

    public override void Interact(PlayerController player)
    {


        print("Collected");



        if (player.currentItem != ItemType.None)

        {
            return;
        }


        if (player.currentItem == ItemType.None)
        {
            player.currentItem = itemToGive;
            spriteRenderer.sprite = null;




            if (player.currentItem == ItemType.None)
            {
                player.currentItem = itemToGive;

            }


            if (player.currentItem == ItemType.Rice)
            {
                player.currentItem = itemToGive;
            }




            if (player.currentItem == ItemType.Avocado)
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

                spriteRenderer.sprite = plateSprite;
                Debug.Log("Changed sprite to plateSprite");

            }
        }
    }
}