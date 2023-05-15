using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTesting : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 100f;
    private CharacterController controller;
    private float verticalRotation = 0f;

void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        bool upMovementKey = Input.GetKey(KeyCode.Q);
        bool downMovementKey = Input.GetKey(KeyCode.E);

        MoveAround();
        MoveUpAndDown(upMovementKey, downMovementKey);
    }

    void MoveAround()
    {
        
        float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        transform.Rotate(Vector3.up * mouseX);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        Vector3 move = transform.forward * vertical + transform.right * horizontal;
        controller.Move(move * Time.deltaTime);

    }

    void MoveUpAndDown(bool up, bool down)
    {
        if (up && transform.position.y <= 2)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if(down && transform.position.y >= 1.3)
        {
            transform.Translate(Vector3.up * -speed * Time.deltaTime);
        }
        
    }

}


