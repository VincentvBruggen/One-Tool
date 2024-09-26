using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueToPercentText : MonoBehaviour
{
    public Slider slider; // Reference to the Slider
    public TMP_Text valueText; // Reference to the TextMeshPro Text
    [SerializeField] bool AngleBool;
    [SerializeField] bool PercentageBool;
    void Start()
    {
        // Initialize the text with the slider's current value as percentage
        UpdateText(slider.value);

        // Add listener to call UpdateText method whenever the slider value changes
        slider.onValueChanged.AddListener(delegate { UpdateText(slider.value); });
    }

    void UpdateText(float value)
    {
        if (PercentageBool)
        {
            float percentage = (value / slider.maxValue) * 100;
            valueText.text = Mathf.RoundToInt(percentage).ToString() + "%";
        }
        else if (AngleBool)
        {
            valueText.text = slider.value.ToString() + "°";
        }
        else
        {
            valueText.text = slider.value.ToString();
        }

    }
}
