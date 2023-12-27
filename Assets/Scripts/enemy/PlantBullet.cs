using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBullet : MonoBehaviour
{

    public float speed;
    public float timeDes;
    Rigidbody2D rb;
 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Transform CannonTransform = FindObjectOfType<Plant>().transform;
        rb.velocity = transform.right * CannonTransform.localScale.x * speed;
        Destroy(gameObject, timeDes);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
