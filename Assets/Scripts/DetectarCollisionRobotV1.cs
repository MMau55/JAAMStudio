using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsV3 : MonoBehaviour
{
    private GameManager gameManager;  // Reference to the GameManager script

    // Start is called before the first frame update
    void Start()
    {
        // Find the GameManager object and get its GameManager script component
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    // This method gets called automatically by Unity when another object enters the trigger collider of this object.
    private void OnTriggerEnter(Collider other)
    {
        // If the object that entered the trigger has the "Player" tag...
        if (other.CompareTag("Player"))
        {
            // Decrease the player's lives count by 1 and destroy the object that had the trigger collider (usually a hazard or enemy).
            gameManager.AddLives(-1);
            //Destroy(gameObject);
        }
    }
}
