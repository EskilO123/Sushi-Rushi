using System.Collections.Generic;
using UnityEngine;

public enum RecipeType { SalmonSushi, AvocadoSushi }

[System.Serializable]
public class Order
{
    public int orderID;
    public RecipeType recipe;
    public float timeCreated;
    
}

public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance;

    public List<Order> activeOrders = new List<Order>();
    public int maxOrdersNormal = 6;

    private float spawnTimer;
    private float currentSpawnInterval;
    private int orderIdCounter = 0;

    void Awake() => Instance = this;

    void Start()
    {
        SetNextSpawnTime();
    }

    void Update()
    {
        if (GameManager.Instance.isGameOver) return;

        spawnTimer -= Time.deltaTime;

        
        bool canSpawn = GameManager.Instance.isSushiRushiActive || activeOrders.Count < maxOrdersNormal;

        if (spawnTimer <= 0 && canSpawn)
        {
            SpawnOrder();
            SetNextSpawnTime();
        }
    }

    void SetNextSpawnTime()
    {
        if (GameManager.Instance.isSushiRushiActive)
        {
            currentSpawnInterval = Random.Range(1f, 2f); 
        }
        else
        {
            currentSpawnInterval = Random.Range(5f, 15f);
        }
        spawnTimer = currentSpawnInterval;
    }

    void SpawnOrder()
    {
        Order newOrder = new Order();
        newOrder.orderID = orderIdCounter++;
        newOrder.recipe = (Random.value > 0.5f) ? RecipeType.SalmonSushi : RecipeType.AvocadoSushi;

        activeOrders.Add(newOrder);

        
        Debug.Log($"New Customer! Wants: {newOrder.recipe}");
    }

    public void StartRushiMode()
    {
        
    }

    
    public bool DeliverOrder(RecipeType deliveredItem)
    {
        
        foreach (Order order in activeOrders)
        {
            if (order.recipe == deliveredItem)
            {
               
                Debug.Log("Order Complete!");
                activeOrders.Remove(order);

                
                return true;
            }
        }

        
        Debug.Log("Wrong Order! Angry Cat!");
        
        return false;
    }
}