using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour
{
    [SerializeField] private BoxCollider2D m_BoxCollider;
    [SerializeField] public GameObject m_Ore;
    [SerializeField] public GameObject pickUP;

    public float breakTime;

    [SerializeField] public int requiredLevel;

    private Animator anim;

    private void Start()
    {
       anim = GetComponentInChildren<Animator>(); 
    }
    public void OnBreak(int pickaxeLevel)
    {
        if (pickaxeLevel >= requiredLevel)
        {
            Destroy(gameObject);
            if (pickUP != null)
            {
                Instantiate(pickUP, transform.position, Quaternion.identity);
            }
        }
        else
        {
            anim.SetTrigger("NotAllowed");
        }
    }
}
