using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float spawnInterval = 3f;
    [SerializeField] private float minGapY = 0.3f;
    [SerializeField] private float maxGapY = 0.7f;
    [SerializeField] private float destroyX = -12f;

    private float timer;

    void Update()
    {
        if (GameSpeedManager.Instance == null) return;

        timer += Time.deltaTime;

        float currentInterval = spawnInterval /
            (GameSpeedManager.Instance.CurrentSpeed / 3f);
        currentInterval = Mathf.Clamp(currentInterval, 1.5f, spawnInterval);

        if (timer >= currentInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        // Only vary Y slightly - keeps shards near ground always
        float randomY = Random.Range(minGapY, maxGapY);
        Vector3 spawnPos = new Vector3(
            transform.position.x,
            randomY,
            0
        );

        GameObject obstacle = Instantiate(
            obstaclePrefab,
            spawnPos,
            Quaternion.identity
        );

        ScrollingObject scroller =
            obstacle.AddComponent<ScrollingObject>();
    }
}
