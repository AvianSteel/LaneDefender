using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField] private GameObject snake;
    [SerializeField] private float snakeSpeed;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D endLane;
    [SerializeField] private PlayerController playerController;
    private void Start()
    {
        endLane = GameObject.Find("EndLane").GetComponent<BoxCollider2D>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == ("EndLane"))
        {
            playerController.DecreaseLives();
            Destroy(snake);
        }else if (collision.gameObject.name.Contains("Bullet"))
        {
            playerController.IncreaseScore();
            Destroy(collision.gameObject);
            Destroy(snake);
        }
    }

    private void FixedUpdate()
    {
        rb.position = new Vector2(rb.position.x - snakeSpeed, rb.position.y);
    }
}
