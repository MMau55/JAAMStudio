using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerTest : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    public float sensitivity;

    private Camera cam;
    private Vector3 defaultOffset;
    private float defaultFieldOfView;


    void Start()
    {
        // Ajusta la posición inicial de la cámara
        defaultOffset = offset;
        
        cam = gameObject.GetComponent<Camera>();
        defaultFieldOfView = cam.fieldOfView;

        transform.position = player.transform.position + offset;
    }

    private void LateUpdate()
    {
        // Obtiene la rotación del objeto del jugador
        Quaternion rotation = Quaternion.Euler(0, player.transform.eulerAngles.y, 0);

        // Ajusta la posición y rotación de la cámara
        transform.position = player.transform.position + rotation * offset;
        transform.LookAt(player.transform.position);

        // Gira la cámara con el mouse
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        transform.RotateAround(player.transform.position, Vector3.up, mouseX);
        transform.RotateAround(player.transform.position, Vector3.right, mouseY);

        ChangeFieldfViewOnMovement();
    }

    void ChangeFieldfViewOnMovement()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");
        float fieldOfViewDifference = 10f;
        float speed = 40f;

        if (verticalAxis != 0)
        {
            if((cam.fieldOfView > defaultFieldOfView - fieldOfViewDifference) && (cam.fieldOfView < defaultFieldOfView + fieldOfViewDifference))
            {
                cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, cam.fieldOfView + (verticalAxis * fieldOfViewDifference), speed * Time.deltaTime);
            }           
        }
        else
        {
           cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, defaultFieldOfView, speed * Time.deltaTime);
        }

        /*if (horizontalAxis != 0)
        {

            offset = Mathf.Lerp(offset, offset.normalized * Time.deltaTime, speed * Time.deltaTime);
        }
        else
        {
            offset = Mathf.Lerp(offset, defaultOffset, speed * Time.deltaTime);
        }*/
        
    }
}