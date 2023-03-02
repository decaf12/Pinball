using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuScript : MonoBehaviour
{
    public Button MainMenuButton;
    public Button GravityButton;
    public GameObject MainMenu;
    public GameObject OptionsMenu;

    private static Vector3[] GravityArray = {new Vector3(0, -1000f, -5f), new Vector3(0, -1000f, -20f)};
    private static int GravityID = 0;

    void Awake()
    {
        MainMenuButton.onClick.AddListener(BackToMain);
        GravityButton.onClick.AddListener(ToggleGravity);
    }

    private void BackToMain()
    {
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    private void ToggleGravity()
    {
        GravityID = 1 - GravityID;
        Physics.gravity = GravityArray[GravityID];

        string gravityMessage = (GravityID == 0) ? "Default gravity" : "High gravity";
        print($"{gravityMessage}");
    }
}
