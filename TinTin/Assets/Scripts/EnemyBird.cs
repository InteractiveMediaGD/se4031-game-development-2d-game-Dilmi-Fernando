using UnityEngine;

public class EnemyBird : MonoBehaviour
{
    [SerializeField] private float damageAmount = 20f;
    [SerializeField] private float autoDestroyTime = 8f;
    private bool hasHitPlayer = false;

    void Start()
    {
        Destroy(gameObject, autoDestroyTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Hit by projectile
        if (other.CompareTag("Projectile"))
        {
            ScoreManager.Instance.AddScore(2);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        // Hit by player
        if (other.CompareTag("Player") && !hasHitPlayer)
        {
            hasHitPlayer = true;
            HealthManager.Instance.TakeDamage(damageAmount);
            CameraShake.Instance.Shake();
            Destroy(gameObject);
        }

        Debug.Log("Bird touched by: " + other.tag);

    }

}
