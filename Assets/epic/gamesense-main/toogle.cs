using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ToggleGameObjectOnKeyPress : MonoBehaviour
{
    public GameObject objectToToggle;
    public KeyCode toggleKey = KeyCode.Insert;
    public string requiredComputerName = "fortnitepropc";
    public float fadeDuration = 1.0f; // Duration of the fade effect

    private List<Image> images = new List<Image>();
    private Dictionary<Image, Color> originalColors = new Dictionary<Image, Color>();
    private bool isFading = false;

    void Start()
    {
        if (objectToToggle != null)
        {
            // Get all Image components in the objectToToggle and its children
            images.AddRange(objectToToggle.GetComponentsInChildren<Image>());
            foreach (var img in images)
            {
                originalColors[img] = img.color;
            }
        }
    }

    void Update()
    {
        // Check if the current computer name matches the required name
        if (SystemInfo.deviceName.ToLower() == requiredComputerName.ToLower())
        {
            // Check if the toggle key is pressed
            if (Input.GetKeyDown(toggleKey) && !isFading)
            {
                // Toggle the GameObject with fade effect
                if (objectToToggle.activeSelf)
                {
                    StartCoroutine(FadeOutAndDeactivate());
                }
                else
                {
                    objectToToggle.SetActive(true);
                    StartCoroutine(FadeIn());
                }
            }
        }
    }

    private IEnumerator FadeOutAndDeactivate()
    {
        isFading = true;
        float rate = 1.0f / fadeDuration;
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            foreach (var img in images)
            {
                Color tempColor = img.color;
                img.color = new Color(tempColor.r, tempColor.g, tempColor.b, Mathf.Lerp(originalColors[img].a, 0, progress));
            }
            progress += rate * Time.deltaTime;
            yield return null;
        }

        foreach (var img in images)
        {
            img.color = new Color(originalColors[img].r, originalColors[img].g, originalColors[img].b, 0);
        }

        objectToToggle.SetActive(false);
        isFading = false;
    }

    private IEnumerator FadeIn()
    {
        isFading = true;
        float rate = 1.0f / fadeDuration;
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            foreach (var img in images)
            {
                Color tempColor = img.color;
                img.color = new Color(tempColor.r, tempColor.g, tempColor.b, Mathf.Lerp(0, originalColors[img].a, progress));
            }
            progress += rate * Time.deltaTime;
            yield return null;
        }

        foreach (var img in images)
        {
            img.color = originalColors[img];
        }

        isFading = false;
    }
}
