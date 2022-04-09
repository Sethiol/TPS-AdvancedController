using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedCameraController : MonoBehaviour
{
    [SerializeField] private bool LockCursor;
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void LateUpdate()
    {
        if (FindObjectOfType<UIController>().CancelAllMovement == true) return;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
