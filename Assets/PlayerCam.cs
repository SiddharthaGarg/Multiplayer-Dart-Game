using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{

    [SerializeField] float sensX;
    [SerializeField] float sensY;
    float yRotation;
    float xRotation;
    float mouseX;
    float mouseY;
    bool rotationAllowed = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Invoke(nameof(RotateNow), 1f);
    }
    // Update is called once per frame
    void Update()
    {
        if (rotationAllowed && PlayerManager.input_enabled)
        {
            mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
            yRotation += mouseX;
            xRotation -= mouseY;
            Mathf.Clamp(xRotation, -90f, 90f);
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        }


    }
    void RotateNow()
    {
        rotationAllowed = true;
    }
}
