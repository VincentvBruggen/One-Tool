using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class MiningController : MonoBehaviour
{
    [SerializeField] LayerMask m_LayerMask;

    [SerializeField] GameObject toolHolder;
    [SerializeField] GameObject hoverEffectPref;

    [SerializeField] GameObject toolManager;

    Vector3 hoverPos;
    Vector3 mousePos;
    GameObject hoverObject;
    GameObject blockToMine;
    // Start is called before the first frame update
    void Start()
    {
        hoverObject = Instantiate(hoverEffectPref);
        hoverObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        hoverObject.transform.position = hoverPos;

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Camera.main.transform.position;
        mousePos.z = toolHolder.transform.position.z;

        toolHolder.transform.up = mousePos;
        transform.position = mousePos + Camera.main.transform.position;

        if(Input.GetButton("Fire1") && blockToMine != null)
        {
            Ore ore = blockToMine.GetComponent<Ore>();
            if(ore == null) { return; }

            ore.OnBreak(toolManager.GetComponent<ToolManager>().toolLevel);
        }

        CheckForHover();
    }

    void CheckForHover()
    {
        RaycastHit2D hit = Physics2D.Raycast(toolHolder.transform.position, mousePos, 3, m_LayerMask);

        Debug.DrawRay(toolHolder.transform.position, mousePos);
        if (hit.collider != null)
        {
            hoverPos = hit.collider.transform.position;
            blockToMine = hit.collider.gameObject;
            hoverObject.SetActive(true);
        }
        else
        {
            hoverObject.SetActive(false);
            blockToMine = null;
        }
    }
}
