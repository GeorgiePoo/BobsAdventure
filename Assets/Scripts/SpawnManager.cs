using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private Vector3 spawnPos = new Vector3(23, -1, -1);
    public Vector2 spawnTimeRange;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
