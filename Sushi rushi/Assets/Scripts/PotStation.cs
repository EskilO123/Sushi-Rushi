using UnityEngine;
using System.Collections;

public class PotStation : Station
{
    public bool isCooking = false;
    public bool isReady = false;
    public int portions = 0; 

    private float cookTime = 12f;

    public override void Interact(PlayerController player)
    {
        
        if (player.currentItem == ItemType.Ris && !isCooking && !isReady && portions == 0)
        {
            player.currentItem = ItemType.Ris;
            StartCoroutine(CookRice());
            
        }
        
        else if (player.currentItem == ItemType.Tallrik && isReady && portions > 0)
        {
            player.currentItem = ItemType.RisTallrik; 
            portions--;

            Debug.Log("Hämtade ris. Portioner kvar: " + portions);

            
            if (portions <= 0)
            {
                isReady = false;
            }
            
        }
    }

    IEnumerator CookRice()
    {
        isCooking = true;
        Debug.Log("Kokar Ris");

            yield return new WaitForSeconds(cookTime);

        isCooking = false;
        isReady = true;
        portions = 2;
        Debug.Log("Ris Klart");

    }
}