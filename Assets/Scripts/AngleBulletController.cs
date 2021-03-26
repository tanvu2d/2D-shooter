using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleBulletController : MonoBehaviour
{
    public GameObject destroyBL;
    

    void Start ()
    {
       
    }
    void Update()
    {
        Destroy(gameObject, 5f);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Wall") && !col.gameObject.CompareTag("Angle"))
        {
            GameObject destroyBullet = Instantiate(destroyBL, transform.position, transform.rotation);
            Destroy(destroyBullet, 0.3f);
            Destroy(gameObject);
        }
         if (col.gameObject.CompareTag ("Player"))
        {
            PlayerController player = col.gameObject.GetComponent<PlayerController>();
            player.Damage(-1);

        }
    }

}