using UnityEngine;

public class SlimeController : MonoBehaviour
{
    [SerializeField] private float slimeSpeed;
    private int slimeHealth = 3;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject slime;
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
            Destroy(slime);
        }
        else if (collision.gameObject.name.Contains("Bullet"))
        {
            slimeHealth--;
            if (slimeHealth < 1)
            {
                playerController.IncreaseScore();
                Destroy(collision.gameObject);
                Destroy(slime);
            }

        }
    }
    private void FixedUpdate()
    {
        rb.position = new Vector2(rb.position.x - slimeSpeed, rb.position.y);
    }
}
