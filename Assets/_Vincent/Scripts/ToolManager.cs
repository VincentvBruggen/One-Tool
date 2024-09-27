using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    public int toolLevel = 0;
    public SpriteRenderer toolVisual;

    [SerializeField] Sprite[] toolsList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        toolVisual.sprite = toolsList[toolLevel];
    }

    public float GetMiningSpeed()
    {
        switch(toolLevel)
        {
            case 0:
                return 1.5f;
            case 1:
                return 1.2f;
            case 2:
                return 0.7f;
            case 3:
                return 0.5f;
            case 4:
                return 0.35f;
        }
        return 1.5f;
    }

    public void UpgradeTool()
    {
        if(toolLevel <= 5)
        { 
            toolLevel += 1; 
        }
    }
}
