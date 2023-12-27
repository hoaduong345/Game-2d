using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private float minX, maxX, minY, maxY;

    [SerializeField] private Transform[] points;

    [SerializeField] private GameObject[] Enemys;

    [SerializeField] private float timeSpawn;

    private float timeNextSpawnEnemys;
    void Start()
    {
        maxX = points.Max(points => points.position.x);
        minX = points.Min(points => points.position.x);

        maxY = points.Max(points => points.position.y);
        minY = points.Min(points => points.position.y);
    }

    void Update()
    {
        timeNextSpawnEnemys += Time.deltaTime;

        if (timeNextSpawnEnemys >= timeSpawn)
        {
            timeNextSpawnEnemys = 0;
            CreateEnemy();
        }
    }
    private void CreateEnemy()
    {
        int numberEnemy = Random.Range(0, Enemys.Length);

        Vector2 posicionRandom = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        Instantiate(Enemys[numberEnemy], posicionRandom, Quaternion.identity);
    }
}
