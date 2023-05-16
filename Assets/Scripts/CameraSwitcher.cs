
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public GameObject player1;
     public GameObject player2;
     public Camera camera1;
     public Camera camera2;

     /*private void Update()
     {
         if (Input.GetKeyDown(KeyCode.F))
         {
             // Desactiva el movimiento de los jugadores al presionar "F"
             player1.GetComponent<CharacterController>().enabled = false;
             player2.GetComponent<CharacterController>().enabled = false;

             // Activa la cámara del jugador 2 y desactiva la del jugador 1
             camera2.enabled = true;
             camera1.enabled = false;
         }
         else
         {
             // Activa la cámara del jugador 1 y desactiva la del jugador 2
             camera1.enabled = true;
             camera2.enabled = false;

             // Activa el movimiento de los jugadores
             player1.GetComponent<CharacterController>().enabled = true;
             player2.GetComponent<CharacterController>().enabled = true;
         }
     }*/

    private PlayerControllerTesting player1Controller;
    private PlayerControllerTesting player2Controller;

    void Start()
    {
        player1Controller = player1.GetComponent<PlayerControllerTesting>();
        player2Controller = player2.GetComponent<PlayerControllerTesting>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

            Debug.Log("F");

            // Desactiva el movimiento de los jugadores al presionar "F"
            player1Controller.canMove = false;
            player2Controller.canMove = true;

            // Activa la cámara del jugador 2 y desactiva la del jugador 1
            camera2.enabled = true;
            camera1.enabled = false;
        }
        else
        {

            Debug.Log("Fn´t");

            // Activa la cámara del jugador 1 y desactiva la del jugador 2
            camera1.enabled = true;
            camera2.enabled = false;

            // Activa el movimiento de los jugadores
            player1Controller.canMove = true;
            player2Controller.canMove = false;
        }
    }

}


