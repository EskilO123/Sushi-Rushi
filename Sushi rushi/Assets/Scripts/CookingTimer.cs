using UnityEngine;
using UnityEngine.UI;

public class CookingTimer : MonoBehaviour
{
    public Slider slider;
    public float countdownTime = 12f;

    private float timeRemaining;

    void Start()
    {
        timeRemaining = countdownTime;
        slider.maxValue = countdownTime;
        slider.value = countdownTime;
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            slider.value = timeRemaining;
        }
        else
        {
            timeRemaining = 0;
            slider.value = 0;
            OnCountdownFinished();
        }
    }

    void OnCountdownFinished()
    {
        Debug.Log("Countdown Finished!");

        enabled = false;
    }


}