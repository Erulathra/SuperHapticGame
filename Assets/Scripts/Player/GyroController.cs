using System.Collections;
using UnityEngine;

public class GyroController : MonoBehaviour
{
    [field: SerializeField]
    public Vector3 Sensivity { get; private set; } = new Vector3(0.005f, 0.005f, 0.005f);

    private Vector3 currentRotation;
    
    void Update()
    {
        JSL.IMU_STATE imuState = JSL.JslGetIMUState(0);
        JSL.JOY_SHOCK_STATE simpleState = JSL.JslGetSimpleState(0);
        
        if ((simpleState.buttons & (1 << JSL.ButtonMaskPlus)) != 0)
        {
            currentRotation = Vector3.zero;
        }
        
        currentRotation += new Vector3(imuState.gyroY * Sensivity.x, imuState.gyroZ * Sensivity.y, 0f);
        transform.rotation = Quaternion.Euler(currentRotation);
    }
}
