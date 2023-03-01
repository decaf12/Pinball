using UnityEngine;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject PauseMenu;
    public Button ReturnToGame;
    private bool IsPaused = false;

    void Awake()
    {
        ReturnToGame.onClick.AddListener(Unpause);
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
}
