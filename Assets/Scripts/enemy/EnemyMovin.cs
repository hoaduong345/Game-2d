using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovin : MonoBehaviour
{

    public GameObject player;
    public float speed;
    float khoangcach;
    void Update()
    {
        khoangcach = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float goc = Mathf.Atan2(direction.y, direction.x);
        if (khoangcach < 5)
        {
            transform.position =
         Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * goc);
        }


    }
}
