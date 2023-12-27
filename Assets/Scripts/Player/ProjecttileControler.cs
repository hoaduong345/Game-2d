using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjecttileControler : MonoBehaviour
{
    public float bulletSpeed;
    Rigidbody2D myBody;

    private void Awake()
     {
        myBody = GetComponent<Rigidbody2D>();
        // truc z lon hon 0 la 180 do
        if (transform.localRotation.z > 0)
       {
            // Add force cho no 1 cai luc de bay           // ForceMode2D 
            myBody.AddForce(new Vector2(-1, 0) * bulletSpeed, ForceMode2D.Impulse);
        }
        else
        {
            myBody.AddForce(new Vector2(1, 0) * bulletSpeed, ForceMode2D.Impulse);
        }

    }
 
    private void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        Transform playerTransform = FindObjectOfType<PlayerMovement>().transform;
        myBody.velocity = transform.right * playerTransform.localScale.x * bulletSpeed;
    }


    // Update is called once per frame
    void Update()
    {

    }


    public void removeForce()
    {
        myBody.velocity = new Vector2(0, 0);
    }
}
