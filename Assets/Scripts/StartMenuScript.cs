using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class StartMenuScript : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionsMenu;
    public Button PlayGameButton;
    public Button QuitGameButton;
    public Button OptionsButton;

    void Start()
    {
        MainMenu.SetActive(true);
        PlayGameButton.onClick.AddListener(StartGame);
        QuitGameButton.onClick.AddListener(QuitGame);
        OptionsButton.onClick.AddListener(GoToOptions);
    }

    void Awake()
    {
        PlayGameButton.onClick.AddListener(StartGame);
        QuitGameButton.onClick.AddListener(QuitGame);
        OptionsButton.onClick.AddListener(GoToOptions);
    }

    private void StartGame()
    {
        MainMenu.SetActive(false);
    }

    private void GoToOptions()
    {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    private void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
