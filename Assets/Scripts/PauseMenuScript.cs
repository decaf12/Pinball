using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject PauseMenu;
    public Field Game;
    public Button ReturnToGameButton;
    public Button MainMenuButton;
    public Button QuitGameButton;
    private bool IsPaused;

    void Start()
    {
        IsPaused = false;
    }
    void Awake()
    {
        ReturnToGameButton.onClick.AddListener(Unpause);
        MainMenuButton.onClick.AddListener(ReturnToMainMenu);
        QuitGameButton.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Unpause()
    {
        IsPaused = false;
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    private void Pause()
    {
        IsPaused = true;
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    private void QuitGame()
    {
        EditorApplication.isPlaying = false;
        Application.Quit();
    }

    private void ReturnToMainMenu()
    {
        Game.ResetGame();
        Unpause();
        PauseMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
}
