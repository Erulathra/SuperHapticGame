using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RumbleController : MonoBehaviour
{
    [SerializeField]
    private Transform player ;

    public Transform nearestEnemy { get; private set; }

    private void Update()
    {
        if (!enabled)
            return;

        Enemy[] enemiesComponents = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        
        float maxDot = -1f;
        foreach (Enemy enemy in enemiesComponents)
        {
            if (enemy == null)
                return;
            
            Vector3 playerToEnemy = (enemy.transform.position - player.position).normalized;
            float enemyAngle = Vector3.Dot(playerToEnemy, player.forward);
            if (maxDot < enemyAngle)
            {
                maxDot = enemyAngle;
                nearestEnemy = enemy.transform;
            }
        }
        
        float rumble = Mathf.Clamp(maxDot, 0f, 1f);
        rumble = Mathf.Pow(rumble, 5f);
        JSL.JslSetHDRumble(0, rumble, rumble, rumble, rumble);
    }
}