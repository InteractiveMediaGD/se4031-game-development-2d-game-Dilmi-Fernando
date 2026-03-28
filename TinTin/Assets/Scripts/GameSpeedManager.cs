using UnityEngine;

public class GameSpeedManager : MonoBehaviour
{
    public static GameSpeedManager Instance;

    [SerializeField] private float startSpeed = 3f;
    [SerializeField] private float maxSpeed = 8f;
    [SerializeField] private float speedIncreaseRate = 0.1f;

    public float CurrentSpeed { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        CurrentSpeed = startSpeed;
    }

    void Update()
    {
        // Gradually increase speed up to max
        if (CurrentSpeed < maxSpeed)
        {
            CurrentSpeed += speedIncreaseRate * Time.deltaTime;
            CurrentSpeed = Mathf.Min(CurrentSpeed, maxSpeed);
        }
    }

    public void ResetSpeed()
    {
        CurrentSpeed = startSpeed;
    }
}