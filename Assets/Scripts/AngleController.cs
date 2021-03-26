using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;

public class AngleController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public GameObject bulletPrefap;
    public Transform firePoint;
    public Transform target;

    float timeDelayShoot = 0.9f;
    float counterTime = 0.9f;
    public float disTance;
    bool isShooting = false;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckRange();
        if (isShooting)
        {
            counterTime += Time.deltaTime;
            if (counterTime >= timeDelayShoot)
            {
                Shoot();
                counterTime = 0;
            }
        }
    }
    
    void Shoot ()
    {
        GameObject bullet = Instantiate(bulletPrefap, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * 10f, ForceMode2D.Impulse);
    }

    void CheckRange ()
    {
        disTance = Vector2.Distance(transform.position, target.position);

        if (disTance < 10)
        {
            isShooting = true;
        }
        else
        {
            isShooting = false;
        }
    }

    
}
