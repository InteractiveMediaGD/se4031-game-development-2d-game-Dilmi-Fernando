using UnityEngine;

public class BackgroundLooper : MonoBehaviour
{
    [SerializeField] private float speedMultiplier = 0.4f;
    private float backgroundWidth;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        backgroundWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        if (GameSpeedManager.Instance == null) return;

        float speed = GameSpeedManager.Instance.CurrentSpeed * speedMultiplier;
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x <= startPosition.x - backgroundWidth)
        {
            transform.position = startPosition;
        }
    }
}