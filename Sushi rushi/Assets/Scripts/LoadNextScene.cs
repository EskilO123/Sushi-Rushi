using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private Button startButton;

    void Start()
    {
        startButton = GetComponent<Button>();

        if (startButton != null)
        {
            startButton.onClick.AddListener(LoadGameScene);
        }
    }

    public void LoadGameScene()
    {
        Debug.Log("Loading game scene...");
        SceneManager.LoadScene("Scene2");
    }
}