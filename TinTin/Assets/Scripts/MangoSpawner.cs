using UnityEngine;

public class MangoSpawner : MonoBehaviour
{
    [SerializeField] private GameObject mangoPrefab;
    [SerializeField] private float spawnInterval = 5f;
    [SerializeField] private float spawnY = -2f;
    private float timer;

    void Update()
    {
        if (GameSpeedManager.Instance == null) return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnMango();
            timer = 0f;
        }
    }

    void SpawnMango()
    {
        Vector3 spawnPos = new Vector3(
            transform.position.x,
            spawnY,
            0
        );

        GameObject mango = Instantiate(
            mangoPrefab,
            spawnPos,
            Quaternion.identity
        );

        mango.AddComponent<ScrollingObject>();
    }
}
