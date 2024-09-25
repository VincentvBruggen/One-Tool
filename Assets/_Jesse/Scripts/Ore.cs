using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour
{
    [SerializeField] private BoxCollider2D m_BoxCollider;
    [SerializeField] public GameObject m_Ore;
    [SerializeField] public GameObject pickUP;

    private float breakTime;
    private float spawnRate;

    [SerializeField] private int requiredLevel;
    [SerializeField] private int pickaxeLevel;

    private Animator anim;

    private void Start()
    {
       anim = GetComponentInChildren<Animator>(); 
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
        if (pickaxeLevel >= requiredLevel)
        {
            Destroy(gameObject);
            Instantiate(pickUP, transform.position, Quaternion.identity);
        }
        else
        {
            anim.SetTrigger("NotAllowed");
        }
    }
}
