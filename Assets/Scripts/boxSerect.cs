using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class boxSerect : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;
    public GameObject Gold;

    public Transform left;
    public Transform right;
    bool open = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Open", open);
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.CompareTag  ("Player"))
        { 
            open = true;

            if (open)
            {
                Destroy(gameObject, 0.5f);
                 Instantiate(Gold, left.position, left.rotation);
                 Instantiate(Gold, right.position, right.rotation);


            }
        }    
    }
}
