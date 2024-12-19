using UnityEngine;

public class Enemy : MonoBehaviour
{

    // Adjust the speed for the application.
    public float speed = 1.0f;

    // The target (cylinder) position.
    private GameObject target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var step =  speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }
}
