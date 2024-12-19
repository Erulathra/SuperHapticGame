using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RumbleController : MonoBehaviour
{
    [SerializeField]
    private List<Transform> enemies;
    
    [SerializeField]
    private Transform player ;

    [SerializeField]
    private Transform nearestEnemy;

    private void Update()
    {
        // if (!enabled)
        //     return;
        //
        // float maxDot = -1f;
        // foreach (Transform enemy in enemies)
        // {
        //     Vector3 playerToEnemy = (enemy.position - player.position).normalized;
        //     float enemyAngle = Vector3.Dot(playerToEnemy, player.forward);
        //     if (maxDot < enemyAngle)
        //     {
        //         maxDot = enemyAngle;
        //         nearestEnemy = enemy;
        //     }
        // }
        //
        // float rumble = Mathf.Clamp(maxDot, 0f, 1f);
        // Debug.Log(rumble);
        
        // JSL.JslSetRumble(0, rumble, rumble);
        // Gamepad.current.SetMotorSpeeds(rumble, rumble);
        foreach (Gamepad gamepad in Gamepad.all)
        {
            gamepad.SetMotorSpeeds(100f, 100f);
        }
    }
}