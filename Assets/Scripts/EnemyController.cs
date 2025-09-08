using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject slime;
    [SerializeField] private GameObject snake;
    [SerializeField] private GameObject snail;
    [SerializeField] private float spawnDelay = 1f;

    //Stats for each enemy
    [SerializeField] private float slimeSpeed;
    private int slimeHealth;

    [SerializeField] private float snailSpeed;
    private int snailHealth;

    [SerializeField] private float snakeSpeed;
    private int snakeHealth;


    private Coroutine enemySpawn;

    private int enemyInt;
    private int enemyPos;

    private int lives;
    [SerializeField] private PlayerController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lives = playerController.Lives;
        StartCoroutine(EnemySpawn());
    }
    IEnumerator EnemySpawn()
    {
        while (lives >= 1)
        {
            enemyInt = Random.Range(0, 3);
            enemyPos = Random.Range(0, spawnPoints.Length-1);
            if (enemyInt == 0)
            {
                Instantiate(snake, new Vector2(spawnPoints[enemyPos].transform.position.x, 
                    spawnPoints[enemyPos].transform.position.y), Quaternion.identity);
            } else if (enemyInt == 1)
            {
                Instantiate(snail, new Vector2(spawnPoints[enemyPos].transform.position.x,
                    spawnPoints[enemyPos].transform.position.y), Quaternion.identity);
            }
            else
            {
                Instantiate(slime, new Vector2(spawnPoints[enemyPos].transform.position.x,
                    spawnPoints[enemyPos].transform.position.y), Quaternion.identity);
            }
            yield return new WaitForSecondsRealtime(spawnDelay);
        }
    }
    private void Update()
    {
        lives = playerController.Lives;
    }
}
