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

    public void UpgradeTool()
    {
        if(toolLevel <= 5)
        { 
            toolLevel += 1; 
        }
    }
}
