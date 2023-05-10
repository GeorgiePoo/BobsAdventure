using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    public GameObject[] platformPrefabs;
    public int numberOfPlatforms;
    private Vector3 spawnPos = new Vector3(28, 30, -48);
    private PlayerController playerControllerScript;
    public Vector2 spawnTimeRange;

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
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            if(playerControllerScript.gameOver == false)
            {
                GameObject randomPlatformPrefab = platformPrefabs[Random.Range(0, platformPrefabs.Length)];

                Instantiate(randomPlatformPrefab, spawnPos, randomPlatformPrefab.transform.rotation);

                //Random Time Spawns
                float waitTime = Random.Range(spawnTimeRange.x, spawnTimeRange.y);
                yield return new WaitForSeconds(waitTime);
            }
        }
    }
}
