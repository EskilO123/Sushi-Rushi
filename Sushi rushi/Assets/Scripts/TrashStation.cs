using UnityEngine;

public class TrashStation : Station
{
    [SerializeField] GameObject grabPoint;

    SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = grabPoint.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Interact(PlayerController player)
    {
        if (player.currentItem != ItemType.None)
        {
            spriteRenderer.sprite = null;
            player.currentItem = ItemType.None;
        }
    }
}
