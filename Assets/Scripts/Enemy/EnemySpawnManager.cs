using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform playerTransform;
    public int numberOfEnemiesToSpawn = 10;
    public float spawnRadius = 5.0f;
    public int enemies = 0;
    public int numOfSpawn = 5;

    public GameObject droppedItem;
    public bool gameFinished = false;

    void Start()
    {
        // 在游戏开始时生成怪物
        SpawnEnemy();
        droppedItem.SetActive(false);
        Debug.Log("隐藏掉落物品");
    }
    
    void Update()
    {
        if(gameFinished == true)
        {
            Debug.Log("战斗结束");
            droppedItem.SetActive(true);
            Debug.Log("掉落物品");
        }
    }
    
    public void SpawnEnemy()
    {
        for (int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            // 随机生成一个位置
            Vector3 randomPosition = playerTransform.position + Random.insideUnitSphere * spawnRadius;
            randomPosition.z = 0.0f;

            // 实例化敌人Prefab
            GameObject enemyInstance = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
            enemies++;

            // 获取生成的敌人的敌人控制脚本（假设脚本名为 EnemyController）
            EnemyController enemyController = enemyInstance.GetComponent<EnemyController>();

            if (enemyController != null)
            {
                // 将玩家的Transform分配给敌人脚本
                enemyController.player = playerTransform;
            }
        }
        --numOfSpawn;
    }
}