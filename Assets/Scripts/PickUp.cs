using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public string playerTag = "Player2";
    public string endObjectTag = "EndObject";
    private GameObject player;
    private bool isPickedUp = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isPickedUp && other.CompareTag(playerTag))
        {
            // Check if the player is the one who should pick up the object
            if (other.CompareTag(playerTag))
            {
                // Set isPickedUp to true and disable object's collider and renderer
                isPickedUp = true;
                GetComponent<Collider>().enabled = false;
                GetComponent<Renderer>().enabled = false;

                // Display message that object has been picked up
                Debug.Log("Object picked up.");
            }
            else
            {
                // Display message that only player 2 can pick up the object
                Debug.Log("Only Player 2 can pick up the object.");
            }

            if (isPickedUp && other.CompareTag(endObjectTag))
            {
                // Display message that game has ended
                Debug.Log("Game Over.");
                // Llama a la función EndTheGame() en el objeto "EndObject"
                other.GetComponent<EndGame>().EndTheGame();
                // Add code to end the game here
            }
            else if (!isPickedUp && other.CompareTag(endObjectTag))
            {
                // Display message to pick up the object first
                Debug.Log("You must pick up the object first.");
            }
        }
    }

    /*void OnTriggerStay(Collider other)
    {
        // Check if the player has picked up the object and is touching an end object
        if (isPickedUp && other.CompareTag(endObjectTag))
        {
            // Display message that game has ended
            Debug.Log("Game Over.");

            // Add code to end the game here
        }
        else if (!isPickedUp && other.CompareTag(endObjectTag))
        {
            // Display message to pick up the object first
            Debug.Log("You must pick up the object first.");
        }
    }*/
}
