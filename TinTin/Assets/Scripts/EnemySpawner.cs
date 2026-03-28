using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnInterval = 4f;
    [SerializeField] private float spawnY = -2f;
    private float timer;

    void Update()
    {
        if (GameSpeedManager.Instance == null) return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPos = new Vector3(
            transform.position.x,
            spawnY,
            0
        );

        GameObject enemy = Instantiate(
            enemyPrefab,
            spawnPos,
            Quaternion.identity
        );

        enemy.AddComponent<ScrollingObject>();
    }
}
