using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    //public float mouseSensitivity = 100f;

    private CharacterController controller;
    //private float verticalRotation = 0f;

    public bool isControlled = false;

    void Start()
    {
        isControlled = true;
        controller = GetComponent<CharacterController>();
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        /*float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        }

        if (Input.GetKey(KeyCode.A))
        {

            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        }
        if (Input.GetKey(KeyCode.D))
        {

            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        }

        transform.Rotate(Vector3.up * mouseX);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);*/

        if(isControlled)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            //transform.position += movement * speed * Time.deltaTime;
            controller.Move(movement * speed * Time.deltaTime);
        }

    }
}