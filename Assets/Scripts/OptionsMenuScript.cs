using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsMenuScript : MonoBehaviour
{
    
    [Header("Gravity Multiplier")]
    public Slider GravityMultiplierSlider;
    public TMP_Text GravityMultiplier;
    public Button ResetGravityButton;

    [Header("Bumper Boost Multiplier")]
    public Slider BumperBoostMultiplierSlider;
    public TMP_Text BumperBoostMultiplier;
    public Button ResetBumperBoostButton;

    [Header("Main Menu")]
    public GameObject MainMenu;
    public Button MainMenuButton;

    [Header("Options Menu")]
    public GameObject OptionsMenu;

    private static float DefaultGravity = -5f;

    void Awake()
    {
        MainMenuButton.onClick.AddListener(BackToMain);

        GravityMultiplierSlider.onValueChanged.AddListener(ModifyGravity);
        BumperBoostMultiplierSlider.onValueChanged.AddListener(ModifyBoost);

        ResetGravityButton.onClick.AddListener(() => ResetSliderValue(GravityMultiplierSlider));
        ResetBumperBoostButton.onClick.AddListener(() => ResetSliderValue(BumperBoostMultiplierSlider));
    }
    
    void Update()
    {
        UpdateSliderValueDisplay(GravityMultiplierSlider, GravityMultiplier);
        UpdateSliderValueDisplay(BumperBoostMultiplierSlider, BumperBoostMultiplier);
    }
    private void BackToMain()
    {
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    private void ModifyGravity(float multiplier)
    {
        Vector3 newGravity = Physics.gravity;
        newGravity.z = DefaultGravity * multiplier;
        Physics.gravity = newGravity;
    }

    private void ModifyBoost(float multiplier)
    {
        ConfigScript.instance.SetBoostMultiplier(multiplier);
    }
    private void ResetSliderValue(Slider slider)
    {
        slider.value = 1;
    }

    private void UpdateSliderValueDisplay(Slider slider, TMP_Text display)
    {
        display.text = $"{slider.value: 0.00}";
    }
}
