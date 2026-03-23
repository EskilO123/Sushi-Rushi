using UnityEngine;
using System.Collections;

public class PotStation : Station
{


    [SerializeField] Sprite cookedRiceSprite;

    SpriteRenderer spriteRenderer;
    [SerializeField] public GameObject grabPoint;


    public bool isCooking = false;
    public bool isReady = false;
    public int portions = 0; 

    private float cookTime = 12f;

   void Start()
    {
        
        spriteRenderer = grabPoint.GetComponent<SpriteRenderer>();
    }


    public override void Interact(PlayerController player)
    {
        
        if (player.currentItem == ItemType.Rice && !isCooking && !isReady && portions == 0)
        {
            player.currentItem = ItemType.Rice;
            StartCoroutine(CookRice());
            spriteRenderer.sprite = null;
            player.currentItem = ItemType.None;

        }
        
        else if (player.currentItem == ItemType.Plate && isReady && portions > 0)
        {
            player.currentItem = ItemType.RicePlate; 
            portions--;

            Debug.Log("Collected Rice. Portions left: " + portions);

            
            if (portions <= 0)
            {
                isReady = false;
            }
            
        }

        if(isReady)
        {
            spriteRenderer.sprite = cookedRiceSprite;
            isReady = false;
            portions = 0;
            player.currentItem = ItemType.CookedRice;
            

            
        }
        else if (!isReady && portions == 0 && !isCooking && player.currentItem == ItemType.Rice)
        {

            StartCoroutine(CookRice());


        }
    }

    IEnumerator CookRice()
    {
        isCooking = true;
        Debug.Log("Cooking Rice");

            yield return new WaitForSeconds(cookTime);

        isCooking = false;
        isReady = true;
        portions = 2;
        Debug.Log("Rice done");
        
    }
}