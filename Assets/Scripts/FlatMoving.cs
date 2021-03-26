using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class FlatMoving : MonoBehaviour
{

    Rigidbody2D rb2d;
    float timer = 2.5f;
    float conterTime = 0;
    int direction = -1;
    float speed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        conterTime += Time.deltaTime;
        if (conterTime >= timer)
        {
            speed *= direction;
            conterTime = 0;
        }
    }
    void FixedUpdate ()
    {
        Vector2 position = rb2d.position;
        position.y = position.y + speed* Time.deltaTime;
        rb2d.MovePosition(position);
    }
}
