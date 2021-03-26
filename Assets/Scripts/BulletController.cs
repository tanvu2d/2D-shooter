using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public GameObject destroyBL;
    void Update ()
    {
        Destroy(gameObject, 5f);
    }
    void OnTriggerEnter2D (Collider2D  col)
    {
       if (!col.gameObject.CompareTag ("Player")   && !col.gameObject.CompareTag("Wall"))
        {
            GameObject destroyBullet = Instantiate(destroyBL, transform.position, transform.rotation);
            Destroy(destroyBullet, 0.3f);
            Destroy(gameObject);
        }
    }
}
