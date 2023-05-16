using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawn : MonoBehaviour
{
    public GameObject ammoPrefab;
    private Vector3 spawnPos = new Vector3(28, -2, 0);
    private readonly float startDelay = 2;
    public Vector2 spawnTimeRange;

    // Start is called before the first frame update
    void Start()
    {
        float waitTime = Random.Range(spawnTimeRange.x, spawnTimeRange.y);
        InvokeRepeating("SpawnAmmo", startDelay, waitTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnAmmo()
    {
        Instantiate(ammoPrefab, spawnPos, ammoPrefab.transform.rotation);
    }
}
