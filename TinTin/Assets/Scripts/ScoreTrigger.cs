using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private bool scored = false;
    private float topY;
    private float bottomY;

    void Start()
    {
        // Get top and bottom obstacle positions from siblings
        Transform parent = transform.parent;
        Transform top = parent.Find("ObstacleTop");
        Transform bottom = parent.Find("ObstacleBottom");

        // Gap boundaries
        topY = top.position.y - (top.localScale.y * 1.5f);
        bottomY = bottom.position.y + (bottom.localScale.y * 1.5f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !scored)
        {
            // Check TinTin is actually in the gap
            float tinTinY = other.transform.position.y;
            if (tinTinY < topY && tinTinY > bottomY)
            {
                scored = true;
                Debug.Log("SCORE +1 - Clean pass!");
                ScoreManager.Instance.AddScore(1);
            }
            else
            {
                Debug.Log("Hit obstacle - no score");
            }
        }
    }
}