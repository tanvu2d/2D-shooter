using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditTransform : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 x = transform.position;
        Vector2 get = target.position;
        Vector2 direction = get - x;
        transform.right = direction;

    }
}
