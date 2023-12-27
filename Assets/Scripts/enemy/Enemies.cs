using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{

 
   
    [SerializeField] private float speed = 5;    
   
    Rigidbody2D myridbody2d;


    private void Start()
    {
        myridbody2d = GetComponent<Rigidbody2D>(); 
        
    
    }
    // Update is called once per frame
    void Update()
    {
       if (isFacingRight())
        {
            myridbody2d.velocity= new Vector2(speed,0f);
        }else
        {
            myridbody2d.velocity = new Vector2(-speed, 0f);
        }
        
    }

    private bool isFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myridbody2d.velocity.x)),transform.localScale.y);

        if (collision.gameObject.tag == "DeadPoint")
        {
            Debug.Log("1");
            string nameNam = collision.gameObject.transform.parent.name;
            Destroy(GameObject.Find(nameNam));
        }
    }

}

