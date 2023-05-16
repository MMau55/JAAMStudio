using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject plant;
    public Collider victoryZoneCollider;
    public float collectionDistance = 2f;

    //private bool player1InsideZone;
    //private bool player2InsideZone;
    private bool plantCollected;
    //private bool bothPlayersInsideZone;

    private int planta = 0;

    private void Start()
    {
        //player1InsideZone = false;
        //player2InsideZone = false;
        plantCollected = false;
        //bothPlayersInsideZone = false;
    }

    private void Update()
    {
        CheckPlantCollection();
        CheckWinCondition();
    }

    private void CheckPlantCollection()
    {
        if (player2.CompareTag("Player") && !plantCollected)
        {
            Debug.Log("Solo el Player 2 puede recoger la planta");
        }

        if (player2.CompareTag("Player2") && !plantCollected)
        {
            float distance = Vector3.Distance(player2.transform.position, plant.transform.position);
            if (distance <= collectionDistance)
            {
                plantCollected = true;
                planta = 1;
                Debug.Log("Player 2 ha recogido la planta");
                Destroy(plant);
            }
            else
            {
                Debug.Log("Player 2 debe acercarse más para recoger la planta");
            }
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player1)
        {
            player1InsideZone = true;
        }

        if (other.gameObject == player2)
        {
            player2InsideZone = true;
        }

        if (other.CompareTag("Player") || other.CompareTag("Player2"))
        {
            bothPlayersInsideZone = player1InsideZone && player2InsideZone;
        }
    }*/

    /*private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player1)
        {
            player1InsideZone = false;
        }

        if (other.gameObject == player2)
        {
            player2InsideZone = false;
        }

        bothPlayersInsideZone = player1InsideZone && player2InsideZone;
    }*/

    private void CheckWinCondition()
    {
        if (planta == 1 && plantCollected/* && plantCollected*/)
        {
            Debug.Log("¡Ambos jugadores están en la zona de victoria! Ganaste.");
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(3);
        }
        /*else if (player2InsideZone && !player1InsideZone && plantCollected)
        {
            Debug.Log("Deben estar ambos jugadores en la zona de victoria para ganar");
        }
        else if (player2InsideZone && !player1InsideZone && !plantCollected)
        {
            Debug.Log("Debes recoger la planta y volver con Artuditu-Z");
        }*/
    }
}

