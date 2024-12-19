using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GyroController gyroController;
    
    [SerializeField]
    private RumbleController rumbleController;

    private void Start()
    {
        JSL.JslConnectDevices();
        
        gyroController.enabled = false;
        rumbleController.enabled = false;
        
        StartCoroutine(Calibrate());
    }

    IEnumerator Calibrate()
    {
        JSL.JslStartContinuousCalibration(0);
        yield return new WaitForSeconds(1f);
        JSL.JslPauseContinuousCalibration(0);

        gyroController.enabled = true;
        rumbleController.enabled = true;
        
        Debug.Log($"Calibration End");
    }
}