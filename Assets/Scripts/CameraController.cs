using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // 回転用ベクトル
    private Vector3 _yRotator;
    private Vector3 _xRotator;

    [Header("縦の感度")]
    public float MouseYSpeed = 2.0f;
    [Header("横の感度")]
    public float MouseXSpeed = 2.0f;

    [Header("カメラの上方向制限角度"),Range(-90,0)]
    public int AnglelimitTop = -90;
    [Header("カメラの下方向制限角度"),Range(0,90)]
    public int AnglelimitBottom = 90;

    [Header("縦方向のエイム用"),SerializeField] private Transform _rotateX;
    [Header("横方向のエイム用"),SerializeField] private Transform _rotateY;

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        // マウスの移動を取得
        float xRotation = Input.GetAxis("Mouse X");

        float yRotation = Input.GetAxis("Mouse Y");

        RotateCamera(xRotation * MouseXSpeed,yRotation * MouseYSpeed);
    }

    // UIから呼ばれる 感度を変える
    public void ReflectSettingValue(float mouseX,float mouseY)
    {
        MouseXSpeed = mouseX;
        MouseYSpeed = mouseY;
    }

    // (縦,横)
    public void RotateCamera(float xRotation,float yRotation)
    {
        // 制限範囲内で回転させる
        _xRotator = new Vector3(Mathf.Clamp(_xRotator.x - yRotation, AnglelimitTop + 0.001f, AnglelimitBottom - 0.001f),0f, 0f);
        // 反映
        _rotateX.localEulerAngles = _xRotator;

        _yRotator = new Vector3(0f,_rotateY.rotation.eulerAngles.y + xRotation,0f);
        // 反映
        _rotateY.localEulerAngles = _yRotator;
    }

    public void SetMouseSpeed(float mouseX,float mosueY)
    {
        MouseXSpeed = mouseX;
        MouseYSpeed = mosueY;
    }
}
