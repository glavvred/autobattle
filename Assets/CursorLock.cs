using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLock : MonoBehaviour
{
    bool isLocked;

    // Start is called before the first frame update
    void Start()
    {
        SetCursorLock(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            SetCursorLock(true);
        } else
        {
            SetCursorLock(false);
        } 

    }

    void SetCursorLock(bool isLocked)
    {
        this.isLocked = isLocked;
        if (isLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
        Cursor.visible = !isLocked;

    }
}
