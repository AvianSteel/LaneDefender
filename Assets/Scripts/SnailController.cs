using UnityEngine;

public class SnailController : MonoBehaviour
{
    [SerializeField] private float snailSpeed;
    private int snailHealth = 5;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject snail;
    [SerializeField] private BoxCollider2D endLane;
    [SerializeField] private PlayerController playerController;
    private void Start()
    {
        endLane = GameObject.Find("EndLane").GetComponent<BoxCollider2D>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == ("EndLane"))
        {
            playerController.DecreaseLives();
            Destroy(snail);
        }
        else if (collision.gameObject.name.Contains("Bullet"))
        {
            snailHealth--;
            if (snailHealth < 1)
            {
                playerController.IncreaseScore();
                Destroy(collision.gameObject);
                Destroy(snail);
            }

        }
    }
    private void FixedUpdate()
    {
        rb.position = new Vector2(rb.position.x - snailSpeed, rb.position.y);
    }
}
