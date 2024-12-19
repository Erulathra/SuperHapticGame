using System;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float timeToDestroy = 5;

    private void Update()
    {
        timeToDestroy -= Time.deltaTime;

        if (timeToDestroy < 0)
        {
            Destroy(gameObject);
        }
    }
}
