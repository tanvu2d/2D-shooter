using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnCollisionEnter2D  (Collision2D col)
    {
        if (col.gameObject.tag ==  "Player")
        {
            PlayerController player = col.gameObject.GetComponent<PlayerController>();
            player.addGold(1);
            Destroy(gameObject);
        }
    }
}
