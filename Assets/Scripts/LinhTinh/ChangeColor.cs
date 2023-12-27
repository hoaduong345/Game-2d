using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public float timebuff;
    float timetest;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Straw"))
        {
            timetest = timebuff;
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            Shared.savebuffspeed = 15;
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        timetest -= Time.deltaTime;
        if (timetest <= 0)
        {
            Shared.savebuffspeed = 0;
        }
    }
}
