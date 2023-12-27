using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompileEnemy : MonoBehaviour
{
    public GameObject enemyMedium;
    public GameObject enemyBig;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Enemy2"))
        //{
        //    Destroy(collision.gameObject);
        //    Instantiate(enemyMedium, transform.position, transform.rotation);
        //}
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("Enemy2") && collision.gameObject.CompareTag("Enemy2"))
        {
           
            Instantiate(enemyMedium, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        //else if (gameObject.CompareTag("Enemy3") && collision.gameObject.CompareTag("Enemy3"))
        //{
            
        //    Instantiate(enemyBig, transform.position, transform.rotation);
        //    Destroy(collision.gameObject);
        //    Destroy(gameObject);
        //}
    }
}
