using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    [SerializeField] private float speedMultiplier = 1f;
    private Vector3 startPosition;
    private float destroyX = -15f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (GameSpeedManager.Instance == null) return;

        float speed = GameSpeedManager.Instance.CurrentSpeed * speedMultiplier;
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Destroy obstacle when off screen left
        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
    }
}