using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class StartMenuScript : MonoBehaviour
{
    public GameObject MainMenu;
    public Button PlayGameButton;
    public Button QuitGameButton;

    void Start()
    {
        MainMenu.SetActive(true);
        PlayGameButton.onClick.AddListener(StartGame);
        QuitGameButton.onClick.AddListener(QuitGame);
    }

    void Awake()
    {
        PlayGameButton.onClick.AddListener(StartGame);
        QuitGameButton.onClick.AddListener(QuitGame);
    }

    private void StartGame()
    {
        MainMenu.SetActive(false);
    }

    private void QuitGame()
    {
        EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
