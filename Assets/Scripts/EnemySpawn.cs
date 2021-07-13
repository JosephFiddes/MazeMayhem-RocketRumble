using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Range(0.1f, 5f)]
    public float maxTBetweenSpawns = 4.0f;
    [Range(0.1f, 5f)]
    public float minTBetweenSpawns = 2.0f;

    public float maxTToMinT = 20f;

    public int spawnFarness = 2;

    public GameObject enemy;
    public GameObject cam;
    
    private Camera subcam;

    private float spawnTimer = 3.0f;

    private float xLo;
    private float xHi;
    private float yLo;
    private float yHi;

    private float init_time;

    // Start is called before the first frame update
    void Start()
    {
        subcam = cam.GetComponent<Camera>();

        yHi = cam.transform.position.y + subcam.orthographicSize;
        xHi = cam.transform.position.x + subcam.orthographicSize * subcam.aspect;

        yLo = cam.transform.position.y - subcam.orthographicSize;
        xLo = cam.transform.position.x - subcam.orthographicSize * subcam.aspect;

        init_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer <= 0.0f)
        {
            // Find location to spawn enemy.
            int edge = Random.Range(1, 5);
            Vector3 spawnLocation = new Vector3(0, 0, 1.19f);

            switch (edge) 
            {
                case 1:
                    spawnLocation.x = xLo - spawnFarness;
                    spawnLocation.y = Random.Range(yLo - spawnFarness, yHi + spawnFarness);
                    break;
                case 2:
                    spawnLocation.x = xHi + spawnFarness;
                    spawnLocation.y = Random.Range(yLo - spawnFarness, yHi + spawnFarness);
                    break;
                case 3:
                    spawnLocation.x = Random.Range(xLo - spawnFarness, xHi + spawnFarness);
                    spawnLocation.y = yLo - spawnFarness;
                    break;
                default:
                    // Should only be if edge = 4.
                    spawnLocation.x = Random.Range(xLo - spawnFarness, xHi + spawnFarness);
                    spawnLocation.y = yHi + spawnFarness;
                    break;
            }

            Instantiate(enemy, spawnLocation, Quaternion.identity);

            spawnTimer = timeBetweenSpawns();
        } else
        {
            spawnTimer -= Time.deltaTime;
        }
    }

    float timeBetweenSpawns()
    {
        float proportion = ((Time.time - init_time) / maxTToMinT);

        if (proportion < 1.0f)
        {
            return maxTBetweenSpawns - (maxTBetweenSpawns - minTBetweenSpawns) * ((Time.time - init_time) / maxTToMinT);
        }
        else
        {
            return minTBetweenSpawns;
        }
    }
}
