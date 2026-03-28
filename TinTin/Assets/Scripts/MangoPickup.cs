using UnityEngine;

public class MangoPickup : MonoBehaviour
{
    [SerializeField] private float healAmount = 20f;
    [SerializeField] private float autoDestroyTime = 5f;

    void Start()
    {
        Destroy(gameObject, autoDestroyTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HealthManager.Instance.HealHealth(healAmount);
            Destroy(gameObject);
        }
    }
}
