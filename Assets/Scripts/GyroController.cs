using System.Collections;
using UnityEngine;

public class GyroController : MonoBehaviour
{
    [field: SerializeField]
    public Vector3 Sensivity { get; private set; } = new Vector3(0.005f, 0.005f, 0.005f);
    
    void Start()
    {
        JSL.JslConnectDevices();

        StartCoroutine(Calibrate());
    }

    IEnumerator Calibrate()
    {
        JSL.JslStartContinuousCalibration(0);
        yield return new WaitForSeconds(1f);
        JSL.JslPauseContinuousCalibration(0);
        
        Debug.Log($"Calibration End");
    }

    void Update()
    {
        JSL.IMU_STATE imuState = JSL.JslGetIMUState(0);
        JSL.JOY_SHOCK_STATE simpleState = JSL.JslGetSimpleState(0);
        
        if ((simpleState.buttons & (1 << JSL.ButtonMaskPlus)) != 0)
        {
            transform.rotation = Quaternion.identity;
        }
        
        // Vector3 gyroEuler = new Vector3(0f, State.gyroZ, 0f);
        Vector3 gyroEuler = new Vector3(imuState.gyroY * Sensivity.x, imuState.gyroZ * Sensivity.y, 0f);
        Vector3 newRotation = transform.rotation.eulerAngles + gyroEuler;

        transform.rotation = Quaternion.Euler(newRotation);
    }
}
