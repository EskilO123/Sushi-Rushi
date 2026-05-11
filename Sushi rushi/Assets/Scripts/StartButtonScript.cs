using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartButtonScript : MonoBehaviour
{
    [SerializeField] string buttonType;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        if (buttonType == "Start")
        {
            GetComponent<SceneLoader>().LoadGameScene();
        }
        if (buttonType == "Leave")
        {
            Debug.Log("Exit");
            Application.Quit();
        }
    }
}
