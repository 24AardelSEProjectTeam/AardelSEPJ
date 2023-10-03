using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSponer : MonoBehaviour
{
    public GameObject monsterPrefab;
    public float spawnRadius = 10f;
    public float spawnInterval = 2f;
    public int monstersPerSpawn = 3;

    private float nextSpawnTime;
   public bool spawnStarted = false; // �� �÷��״� �����̽� ��ư�� ���� �� true�� �����˴ϴ�.
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        //// �����̽� ��ư�� ������ spawnStarted�� true�� ����
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    spawnStarted = true;
        //}

        //// spawnStarted�� true�̸� ���� ���� ����
        //if (spawnStarted && Time.time >= nextSpawnTime)
        //{
        //    for (int i = 0; i < monstersPerSpawn; i++)
        //    {
        //        SpawnMonster();
        //    }
        //    nextSpawnTime = Time.time + spawnInterval;
        //}

        if (spawnStarted && Time.time >= nextSpawnTime)
        {
            for (int i = 0; i < monstersPerSpawn; i++)
            {
                SpawnMonster();
            }
            nextSpawnTime = Time.time + spawnInterval;

            gameManager.OnMonsterSpawned();
        }
    }

    void SpawnMonster()
    {
        float angle = Random.Range(0, 180) * Mathf.Deg2Rad;
        Vector2 spawnPosition = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * spawnRadius;
        Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
    }
}
