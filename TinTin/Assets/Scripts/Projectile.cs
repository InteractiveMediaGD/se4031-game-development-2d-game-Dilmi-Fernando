using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float destroyAfterTime = 2f;

    void Start()
    {
        Destroy(gameObject, destroyAfterTime);
    }

    void Update()
    {
        // Move right
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Destroy on contact with anything except player
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
