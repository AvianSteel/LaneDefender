using UnityEngine;

public class BulletController : MonoBehaviour
{

    private float speed = 0.5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D collide;
    private Rigidbody2D player;
    [SerializeField] private GameObject bullet;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(bullet);
    }
    private void FixedUpdate()
    {
        rb.position = new Vector2(rb.position.x + speed, rb.position.y);
        if (rb.position.x > 9.5f)
        {
            Destroy(bullet);
        }
    }
}
