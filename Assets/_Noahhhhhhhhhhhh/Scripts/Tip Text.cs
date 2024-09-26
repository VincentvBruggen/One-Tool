using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TipText : MonoBehaviour
{
    [SerializeField] private string[] tips;
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        text.SetText(tips[Random.Range(0, tips.Length)]);
    }
}