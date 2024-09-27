using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUpgrade : MonoBehaviour
{
    [SerializeField] private Inventory inventory;

    [SerializeField] private ToolManager toolManager;

    [SerializeField] private int[] upgradeCost;

    private int playerLevel;
    
    public void UpgradeTool()
    {
        if (inventory.currency >= upgradeCost[toolManager.toolLevel])
        {
            inventory.currency -= upgradeCost[toolManager.toolLevel];
            toolManager.toolLevel++;
        }
    }
}