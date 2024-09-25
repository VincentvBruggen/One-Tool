using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour
{
    [SerializeField] private BoxCollider2D m_BoxCollider;
    private float breakTime;
    [SerializeField] private GameObject prefab;

    private void Start()
    {
        
    }

    private void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
             OnBreak();
        }
    }

    private void OnBreak()
    {
        Destroy(gameObject);
        Instantiate(prefab,transform.position , Quaternion.identity);
    }
}
