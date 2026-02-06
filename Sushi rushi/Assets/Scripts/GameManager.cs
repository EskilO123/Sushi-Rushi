using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game Settings")]
    public float totalTime = 180f; 
    public float sushiRushiStartTime = 120f; 

    [Header("Status")]
    public float currentTime;
    public bool isSushiRushiActive = false;
    public bool isGameOver = false;

    [Header("Audio")]
    public AudioSource musicSource;
    public AudioClip calmMusic; 
    public AudioClip rushMusic; 

    void Awake() => Instance = this;

    void Start()
    {
        currentTime = 0;
    }

    void Update()
    {
        if (isGameOver) return;

        currentTime += Time.deltaTime;

        
        if (!isSushiRushiActive && currentTime >= sushiRushiStartTime)
        {
            ActivateSushiRushi();
        }

        
        if (currentTime >= totalTime)
        {
            EndGame();
        }
    }

    void ActivateSushiRushi()
    {
        isSushiRushiActive = true;
        Debug.Log("SUSHI RUSHI STARTED! RUN CAT RUN!");
        
        musicSource.pitch = 1.2f;

        
        OrderManager.Instance.StartRushiMode();
    }

    void EndGame()
    {
        isGameOver = true;
        Time.timeScale = 0; 
        
    }
}