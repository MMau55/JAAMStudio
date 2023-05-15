using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    public float sensitivity;

    void Start()
    {
        // Ajusta la posición inicial de la cámara
        transform.position = player.transform.position + offset;
    }

    void LateUpdate()
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
    }
}
