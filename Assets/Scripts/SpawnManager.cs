using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private Vector3 spawnPos = new Vector3(23, -1, -1);
    public Vector2 spawnTimeRange;
    public int numberOfEnemies;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {

            GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            Instantiate(randomEnemyPrefab, spawnPos, randomEnemyPrefab.transform.rotation);

            //Random Time Spawns
            float waitTime = Random.Range(spawnTimeRange.x, spawnTimeRange.y);
            yield return new WaitForSeconds(waitTime);
        }
        
    }
}
