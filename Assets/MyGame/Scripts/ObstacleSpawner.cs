using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private const string MethodName = "Spawn";
    public static ObstacleSpawner instance;

    public GameObject[] obstacles;

    public bool gameOver;

    public float minSpawnTime, maxSpawnTime;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        StartCoroutine(MethodName);
    }

    private IEnumerator Spawn()
    {
        float waitTime = 1f;

        yield return new WaitForSeconds(waitTime);

        while (!gameOver)
        {
            SpawnObstacle();

            waitTime = Random.Range(minSpawnTime, maxSpawnTime);

            yield return new WaitForSeconds(waitTime);
        }
    }

    private void SpawnObstacle()
    {
        int random = Random.Range(0, obstacles.Length);

        Instantiate(obstacles[random], transform.position, Quaternion.identity);
    }
}
