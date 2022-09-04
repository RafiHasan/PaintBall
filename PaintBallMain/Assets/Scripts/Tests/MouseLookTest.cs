using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookTest : MonoBehaviour
{
    [SerializeField] float sensitivityX = 8f;
    [SerializeField] float sensitivityY = 0.5f;
    float mouseX, mouseY;

    [SerializeField]
    Transform playerCamera;

    [SerializeField] float xClamp = 85f;

    Vector3 targetRotation;

    float xRotation = 0f;

    public void RecieveInput(Vector2 mouseInput)
    {
        mouseX = mouseInput.x * sensitivityX;
        mouseY = mouseInput.y* sensitivityY;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up,mouseX * Time.deltaTime);
        //transform.Rotate(Vector3.up, mouseY * Time.deltaTime);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);

        targetRotation = transform.eulerAngles;
        targetRotation.x = xRotation;
        playerCamera.eulerAngles = targetRotation;
    }
}
