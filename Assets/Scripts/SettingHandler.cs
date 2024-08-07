using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingHandler : MonoBehaviour
{
    private CameraController _cameraController;
    [SerializeField] private int _mouseSens = 100;
    [SerializeField] private TMP_Text _mouseSensText;

    private void Start()
    {
        _cameraController = Camera.main.GetComponent<CameraController>();
        ChangeMouseSens(0);
    }

    // unityのイベントで呼び出す
    public void ChangeMouseSens(int addNumber)
    {
        _mouseSens = Mathf.Clamp(_mouseSens + addNumber,1,1000);
        _cameraController.SetMouseSpeed(_mouseSens * 0.01f,_mouseSens * 0.01f);
        _mouseSensText.text = _mouseSens.ToString();
    }
}
