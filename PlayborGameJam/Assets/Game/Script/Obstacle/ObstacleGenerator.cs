using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] obstacles;
    public List<EnemyController> obstaclesToSpawn;

    [Range(0.1f, 5f)]
    [SerializeField]
    float minSpawnTime = 1f;

    [Range(1f, 10f)]
    [SerializeField]
    float maxSpawnTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        InitializeObstacles();
        StartCoroutine(SpawnRandomObstacles());
    }

    void InitializeObstacles()
    {
        int index = 0;
        Vector3 objectPosition = transform.position;

        for (int i = 0; i < obstacles.Length * 2; i++) // Para cada iteração do loop, um prefab clone será instanciado, setado para falso e adicionado à lista
        {
            switch (index)
            {
                case 0:
                    objectPosition = new Vector3(transform.position.x, 0.85f, 0);
                    break;
                case 1:
                    objectPosition = new Vector3(transform.position.x, 1.2f, 0);
                    break;
                case 2:
                    objectPosition = new Vector3(transform.position.x, 1.9f, 0);
                    break;
                case 3:
                    objectPosition = new Vector3(transform.position.x, -3.6f, 0);
                    break;
                case 4:
                    objectPosition = new Vector3(transform.position.x, -3.75f, 0);
                    break;
            }

            GameObject obj = Instantiate(obstacles[index], objectPosition, Quaternion.identity); // Instantiate() é usada para instanciar um objeto
            obj.SetActive(false); // Desativa o objeto
            obstaclesToSpawn.Add(obj.GetComponent<EnemyController>()); // Adiciona o objeto à lista obstaclestoSpawn

            index++;
            if (index == obstacles.Length)
            {
                index = 0;
            }
        }
    }

    IEnumerator SpawnRandomObstacles()
    {
        Vector3 objectPosition = transform.position;
        float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);

        yield return new WaitForSeconds(spawnTime);

        int index = Random.Range(0, obstaclesToSpawn.Count);

        while (true)
        {
            switch (obstaclesToSpawn[index].gameObject.name)
            {
                case "Obstacle_1(Clone)":
                    objectPosition = new Vector3(transform.position.x, 0.85f, 0);
                    break;
                case "Obstacle_2(Clone)":
                    objectPosition = new Vector3(transform.position.x, 1.2f, 0);
                    break;
                case "Obstacle_3(Clone)":
                    objectPosition = new Vector3(transform.position.x, 1.9f, 0);
                    break;
                case "Obstacle_4(Clone)":
                    objectPosition = new Vector3(transform.position.x, -3.6f, 0);
                    break;
                case "Obstacle_5(Clone)":
                    objectPosition = new Vector3(transform.position.x, -3.75f, 0);
                    break;

            }

            EnemyController obstacle = obstaclesToSpawn[index];

            if (!obstacle.gameObject.activeInHierarchy)
            {
                obstacle.gameObject.SetActive(true);
                obstacle.transform.position = objectPosition;

                FindObjectOfType<AudioManager>().Play(GameSounds.Warning);
                yield return new WaitForSeconds(.4f);
                FindObjectOfType<AudioManager>().Play(GameSounds.Warning);
                yield return new WaitForSeconds(.4f);
                FindObjectOfType<AudioManager>().Play(GameSounds.Warning);

                break;
            }
            else
            {
                index = Random.Range(0, obstaclesToSpawn.Count);
            }

        }

        StartCoroutine(SpawnRandomObstacles());
    }
}
