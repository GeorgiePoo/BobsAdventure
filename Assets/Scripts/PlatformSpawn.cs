using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    public GameObject[] platformPrefabs;
    private Vector3 spawnPos = new Vector3(28, 30, -47);
    public Vector2 spawnTimeRange;
    public int numberOfEnemies;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPlatforms());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnPlatforms()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            GameObject randomPlatformPrefab = platformPrefabs[Random.Range(0, platformPrefabs.Length)];
            Instantiate(randomPlatformPrefab, spawnPos, randomPlatformPrefab.transform.rotation);

            float waitTime = Random.Range(spawnTimeRange.x, spawnTimeRange.y);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
