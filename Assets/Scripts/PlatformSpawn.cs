using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    public GameObject[] platformPrefabs;
    private Vector3 spawnPos = new Vector3(28, 30, -46);
    public Vector2 spawnTimeRange;
    public int numberOfEnemies;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
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
            if(playerControllerScript.gameOver == false)
            {
                GameObject randomPlatformPrefab = platformPrefabs[Random.Range(0, platformPrefabs.Length)];
                Instantiate(randomPlatformPrefab, spawnPos, randomPlatformPrefab.transform.rotation);

                float waitTime = Random.Range(spawnTimeRange.x, spawnTimeRange.y);
                yield return new WaitForSeconds(waitTime);
            }
        }
    }
}
