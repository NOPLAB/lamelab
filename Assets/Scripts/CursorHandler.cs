using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ChangeCursorMode(true);
    }

    public void ChangeCursorMode(bool locking)
    {
        if(locking)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
