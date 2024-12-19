using UnityEngine;

public class GyroController : MonoBehaviour
{
    void Start()
    {
        JSL.JslConnectDevices();
    }

    void Update()
    {
        JSL.IMU_STATE State = JSL.JslGetIMUState(0);
        
        Debug.Log($"Gyro State: ({State.gyroX}, {State.gyroY}, {State.gyroZ})");
    }
}
