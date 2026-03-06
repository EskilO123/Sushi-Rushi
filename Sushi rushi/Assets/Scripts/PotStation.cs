using UnityEngine;
using System.Collections;

public class PotStation : Station
{


    [SerializeField] Sprite cookedRiceSprite;

    SpriteRenderer spriteRenderer;
    SourceStation sourceStation;
   
    [SerializeField] public GameObject grabPoint;


    public bool isCooking = false;
    public bool isReady = false;
    public int portions = 0; 

    private float cookTime = 12f;

   void Start()
    {
        sourceStation = GetComponent<SourceStation>();
        spriteRenderer = grabPoint.GetComponent<SpriteRenderer>();
    }


    public override void Interact(PlayerController player)
    {
        
        if (player.currentItem == ItemType.Rice && !isCooking && !isReady && portions == 0)
        {
            player.currentItem = ItemType.Rice;
            StartCoroutine(CookRice());
            spriteRenderer.sprite = null;

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
        spriteRenderer.sprite = cookedRiceSprite;
    }
}