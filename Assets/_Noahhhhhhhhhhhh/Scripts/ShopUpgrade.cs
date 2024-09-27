using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopUpgrade : MonoBehaviour
{
    private Inventory inventory;

    private ToolManager toolManager;

    [SerializeField] private int[] upgradeCost;

    [SerializeField] private TextMeshProUGUI mainText;
    [SerializeField] private TextMeshProUGUI secondText;

    private void Awake()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        toolManager = GameObject.Find("Player").GetComponent<ToolManager>();
    }

    private void Update()
    {
        mainText.SetText("Upgrade to lvl " + toolManager.toolLevel + 1);
        secondText.SetText("Cost: " + upgradeCost[toolManager.toolLevel + 1]);
    }

    public void UpgradeTool()
    {
        if (inventory.currency >= upgradeCost[toolManager.toolLevel + 1] && toolManager.toolLevel < 5)
        {
            inventory.currency -= upgradeCost[toolManager.toolLevel + 1];
            toolManager.toolLevel++;
        }
    }
}