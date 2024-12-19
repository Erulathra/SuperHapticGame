using UnityEngine;

public class Enemy : MonoBehaviour
{

    // Adjust the speed for the application.
    public float speed = 1.0f;
    private GameObject enemyManager;
    public float step;

    // The target (cylinder) position.
    private GameObject target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        enemyManager = GameObject.FindWithTag("EnemyManager");
    }

    // Update is called once per frame
    void Update()
    {
        step = speed * Time.deltaTime;
        //speed += 1 * Time.deltaTime; //faster
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }

    void OnTriggerEnter(Collider other)
    {
        //later change into bullet
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Collided with player");
            Die();
        }
    }

    public void Die()
    {
        enemyManager.GetComponent<EnemyManager>().RemoveFromEnemyList(this.gameObject);
    }
}
