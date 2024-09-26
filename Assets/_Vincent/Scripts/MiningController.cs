using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningController : MonoBehaviour
{
    [SerializeField] GameObject toolHolder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;

        toolHolder.transform.up = mousePos;
    }
}
