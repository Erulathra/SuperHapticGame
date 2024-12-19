using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    //[SerializeField] float spawnRadius = 5f;
    [SerializeField] int maxEnemiesNumber = 5;
    [SerializeField] private float timeToSpawn = 1f;
    private float spawnCountdown;
    private int enemiesNumber;
    private GameObject target;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        spawnCountdown = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCountdown -= Time.deltaTime;

        if(spawnCountdown <= 0.0f)
        {
            spawnCountdown = timeToSpawn;
            if(enemiesNumber < maxEnemiesNumber)
            {
                SpawnEnemy();
            }
        }
    }

    void SpawnEnemy()
    {
        //Vector3 newPosition = Random.insideUnitCircle * spawnRadius;
        //newPosition.y = target.transform.position.y;
        //Debug.Log(newPosition);
        //Debug.Log(target.transform.position + newPosition);
        //Instantiate (enemyPrefab, target.transform.position + newPosition, transform.rotation);                        

        Vector3 direction = Vector3.zero;
        direction.x = Random.Range(-1.0f, 1.0f);
        direction.z = Random.Range(-1.0f, 1.0f);
        direction = direction.normalized;

        float magnitude = Random.Range(7, 15);

        Vector3 spawnPosition = direction * magnitude;
        spawnPosition += target.transform.position;
        spawnPosition.y = target.transform.position.y;

        Instantiate (enemyPrefab, spawnPosition, transform.rotation);

        Debug.Log(spawnPosition);

        enemiesNumber += 1;
        
    }
}
