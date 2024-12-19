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

    private void OnDestroy()
    {
        JSL.JslDisconnectAndDisposeAll();
    }

    IEnumerator Calibrate()
    {
        JSL.JslResetContinuousCalibration(0);
        JSL.JslStartContinuousCalibration(0);
        yield return new WaitForSeconds(1f);
        JSL.JslPauseContinuousCalibration(0);

        gyroController.enabled = true;
        rumbleController.enabled = true;
        
        Debug.Log($"Calibration End");
    }
}