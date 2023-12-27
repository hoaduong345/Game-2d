using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public Transform spawnBullet;
    public GameObject bullet;
    float time;
    public float starttime;
    // Start is called before the first frame update
    void Start()
    {
        time = starttime;
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0)
        {
            Instantiate(bullet, spawnBullet.position, spawnBullet.rotation);
            time = starttime;
        }
        else
        {
            time -= Time.deltaTime;
        }
    }
}
