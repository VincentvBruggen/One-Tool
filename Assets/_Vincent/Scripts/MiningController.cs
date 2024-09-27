using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class MiningController : MonoBehaviour
{
    [SerializeField] LayerMask m_LayerMask;

    [SerializeField] GameObject toolManager;
    [SerializeField] GameObject toolHolder;
    [SerializeField] GameObject hoverEffectPref;

    Vector3 hoverPos;
    Vector3 mousePos;
    GameObject hoverObject;
    GameObject blockToMine;

    float brealTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        toolManager = GetComponentInParent<GameObject>();
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
            brealTimer += Time.deltaTime;
            Ore ore = blockToMine.GetComponent<Ore>();
            if(ore == null) { return; }

            float breakSpeed = toolManager.GetComponent<ToolManager>().GetMiningSpeed();

            if (brealTimer > breakSpeed)
            {
                ore.OnBreak(toolManager.GetComponent<ToolManager>().toolLevel);
                brealTimer = 0;
            }
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
