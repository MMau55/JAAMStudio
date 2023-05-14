using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public GameObject player2;
    public Vector3 offset;
    public float sensitivity;

    private GameObject currentTarget;
    private Quaternion currentRotation;
    public bool isFollowingPlayer1 = true;

    void Start()
    {
        currentTarget = player;
        // Ajusta la posici�n inicial de la c�mara
        transform.position = player.transform.position + offset;
        currentRotation = transform.rotation;
    }

    void LateUpdate()
    {
        // Gira la c�mara con el mouse
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        transform.RotateAround(player.transform.position, Vector3.up, mouseX);
    }

    void Update()
    {
        // Verifica si se ha presionado la tecla F
        if (Input.GetKeyDown(KeyCode.F))
        {
            isFollowingPlayer1 = !isFollowingPlayer1;
            player.GetComponent<PlayerController>().isControlled = isFollowingPlayer1;
            player2.GetComponent<PlayerController>().isControlled = !isFollowingPlayer1;
            currentTarget = isFollowingPlayer1 ? player : player2;
            currentRotation = transform.rotation;
        }

        transform.position = currentTarget.transform.position + offset;
        // Actualiza la rotaci�n de la c�mara para que mire al jugador actual
        transform.rotation = currentRotation;
        transform.LookAt(currentTarget.transform.position);
    }
}

