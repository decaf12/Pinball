using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject PauseMenu;
    private bool IsPaused;
    // Start is called before the first frame update
    void Start()
    {
        IsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IsPaused = !IsPaused;
            PauseMenu.SetActive(IsPaused);
            Time.timeScale = IsPaused ? 0 : 1;
        }
    }
}
